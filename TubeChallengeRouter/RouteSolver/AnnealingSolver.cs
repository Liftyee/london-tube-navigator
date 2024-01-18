using System.Diagnostics;
using TransportNetwork;
using Serilog;

namespace RouteSolver;

public class AnnealingSolver : ISolver
{
    private ILogger logger;
    
    public AnnealingSolver(ILogger logger)
    {
        this.logger = logger;
    }

    private enum AnnealOpType
    {
        SwapRandom,
        SwapIntermediate,
        Transpose
    }

    private AnnealOpType pickRandomOperation(Random generator)
    {
        const double randomSwapProbability = 0.9;
        if (generator.NextDouble() < randomSwapProbability)
        {
            return AnnealOpType.SwapRandom;
        }
        else
        {
            return AnnealOpType.SwapIntermediate;
        }
    }

    public Route Solve(Network net)
    {
        logger.Information("Annealing route for {A}...", net.ToString());
        // performance tracking metrics
        Stopwatch perfTimer = Stopwatch.StartNew();
        int nIterations = 0;
        
        // generate a random route
        Route route = net.GenerateRandomRoute();
        logger.Debug("Random route: {A}",route.ToString());

        // this function lets me deduplicate the logic later
        static bool AcceptSolution(int oldCost, int newCost, double temperature, Random generator)
        {
            if (newCost < oldCost) return true; // just accept if it's better
            
            // accept the change with probability e^(-delta/T)
            double delta = oldCost - newCost;
            double probability = Math.Exp(delta / temperature);
            return generator.NextDouble() < probability;
        }
        
        // TODO: clean up these constants
        const int tempStepIterations = 1000;
        const int maxIterations = 2000000;
        const double coolDownFactor = 0.99;
        const int noChangeThreshold = 10000;
        double Temperature = 1000;
        int stationA=0, stationB=0, oldCost, newCost, interSegmentIdx, interStationIdx;
        int swapFrom=0, swapTo=0;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();
        
        for (int i = 1; i < maxIterations; i++)
        {
            nIterations++;
            // pick a random pair of stations to swap
            // TODO: implement "swap intermediate" action
            AnnealOpType operation = pickRandomOperation(randomGenerator);

            oldCost = route.Cost;  // int is a value type so we don't have to worry about copy doing referencing things

            switch (operation)
            {
                case AnnealOpType.SwapRandom:
                    do
                    {
                        stationA = randomGenerator.Next(0, route.Count);
                        stationB = randomGenerator.Next(0, route.Count);
                    } while (stationA == stationB); // don't swap station with itself
                    
                    net.Swap(route, stationA, stationB);
                    newCost = route.Cost;
                    
                    break;
                case AnnealOpType.SwapIntermediate:
                    // If we pass by a station while going from A to B, it might be more efficient to move the station
                    // from its position in the route to between A and B
                    
                    do
                    {
                        interSegmentIdx = randomGenerator.Next(0, route.IntermediateStations.Count);
                    } while (route.IntermediateStations[interSegmentIdx].Count == 0); // can't swap if there aren't intermediate stations

                    interStationIdx = randomGenerator.Next(0, route.IntermediateStations[interSegmentIdx].Count);
                    string interStationId = route.IntermediateStations[interSegmentIdx][interStationIdx]; 
                    // find the position of the station in the target stations list, and move it to a place
                    // between the stations at the end of our intermediate station segment
                    swapFrom = route.TargetStations.FindIndex(e => e == interStationId);
                    
                    // the station at the start of the segment has the same index as interSegmentIdx, so add one to get
                    // the end station of the segment
                    swapTo = interStationIdx + 1;

                    if (swapFrom == swapTo)
                    {
                        logger.Warning("Swapping at same position... put a breakpoint here");
                    }

                    if (swapFrom == swapTo - 1)
                    {
                        logger.Warning("Swap will have no effect, station is already in right position");
                    }
                    
                    try
                    {
                        net.TakeAndInsert(route, swapFrom, swapTo);
                    }
                    catch (InvalidOperationException e)
                    {
                        logger.Fatal("Tried to reinsert at the same position {A} (iteration number {B}). Exception {C}", swapFrom, nIterations, e);
                        throw new Exception();
                    }

                    newCost = route.Cost;

                    break;
                case AnnealOpType.Transpose:
                    throw new NotImplementedException("Transpose operation not implemented");
                default:
                    throw new InvalidOperationException("Invalid annealing operation type");
            }

            if (newCost < 0)
            {
                logger.Fatal("Cost of new route (iteration {A}) is negative!", nIterations);
                throw new Exception("Cost is negative!");
            }

            if (AcceptSolution(oldCost, newCost, Temperature, randomGenerator))
            {
                // accept the change (duration and cost have already been updated by the operation)
                loopsSinceLastAccept = 0;
            }
            else
            {
                // reject the change (swap back)
                switch (operation)
                {
                    case AnnealOpType.SwapRandom:
                        net.Swap(route, stationA, stationB);
                        break;
                    case AnnealOpType.SwapIntermediate:
                        if (swapFrom < swapTo)
                        {
                            net.TakeAndInsert(route, swapTo-1, swapFrom);
                        }
                        else
                        {
                            if (swapFrom < route.Count - 1)
                            {
                                net.TakeAndInsert(route, swapTo, swapFrom + 1);
                            }
                            else
                            {
                                net.TakeAndInsert(route, swapTo, swapFrom);
                            }
                        }

                        break;
                    default:
                        throw new InvalidOperationException("Invalid annealing operation type");
                }
                loopsSinceLastAccept++;
            }
            
            // cool down every tempStepIterations cycles to avoid cooling too fast
            if (i % tempStepIterations == 0)
            {
                Temperature *= coolDownFactor;
                
                logger.Debug("Cooled down to {A}",Temperature);
                logger.Debug("Current route: {A} (processing for {B} ms)",route.ToString(), perfTimer.ElapsedMilliseconds);
            }
            
            // if we haven't changed anything for a while then we're probably done
            if (loopsSinceLastAccept >= noChangeThreshold)
            {
                logger.Debug("No change for {A} iterations, stopping annealing",loopsSinceLastAccept);
                break;
            }

            if (nIterations % (maxIterations / 10) == 0)
            {
                logger.Information("{A} percent complete", nIterations*100 / (maxIterations));
            }
        }
        logger.Information("Final route: {A} (found in {B} ms, {C} ms per iteration)",route.ToString(), perfTimer.ElapsedMilliseconds, (perfTimer.ElapsedMilliseconds/(double)nIterations).ToString("0.####"));
        return route;
    }
}