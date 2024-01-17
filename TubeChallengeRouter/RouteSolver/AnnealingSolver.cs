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
        const double randomSwapProbability = 0.5;
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
        
        const int tempStepIterations = 1000;
        const int maxIterations = 2000000;
        const double coolDownFactor = 0.99;
        const int noChangeThreshold = 10000;
        double Temperature = 1000;
        int stationA, stationB, oldCost, newCost, interSegmentIdx, interStationIdx;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();
        Route oldRoute;
        
        for (int i = 1; i < maxIterations; i++)
        {
            nIterations++;
            // pick a random pair of stations to swap
            // TODO: implement "swap intermediate" action
            AnnealOpType operation = pickRandomOperation(randomGenerator);

            oldRoute = route.Copy();
            oldCost = oldRoute.Cost;  // int is a value type so we don't have to worry about copying
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
                    int swapFrom = route.TargetStations.FindIndex(e => e == interStationId);
                    
                    // the station at the start of the segment has the same index as interSegmentIdx, so add one to get
                    // the end station of the segment
                    int swapTo = interStationIdx + 1;
                    
                    net.TakeAndInsert(route, swapFrom, swapTo);
                    newCost = route.Cost;

                    break;
                case AnnealOpType.Transpose:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException();
            }

            if (AcceptSolution(oldCost, newCost, Temperature, randomGenerator))
            {
                // accept the change (duration and cost have already been updated by the operation)
                loopsSinceLastAccept = 0;
            }
            else
            {
                // reject the change (swap back)
                route = oldRoute.Copy(); // TODO: how slow is copying?
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