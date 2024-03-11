using System.Diagnostics;
using TransportNetwork;
using Serilog;

namespace RouteSolver;

public class StrictAnnealingSolver : AnnealingSolver, ISolver
{
    public StrictAnnealingSolver(ILogger logger) : base(logger)
    {
        
    }
    
    public StrictAnnealingSolver(ILogger logger, Action<double> progressCallback) : base(logger, progressCallback)
    {
        
    }
    
    public override Route Solve(Network net)
    {
        ProgressCallback(0); // reset progress bar
        Logger.Information("Annealing route for {A}...", net.ToString());
        // performance tracking metrics
        Stopwatch perfTimer = Stopwatch.StartNew();
        int nIterations = 0;
        
        // generate a random route
        Route route = net.GenerateRandomRoute();
        Logger.Debug("Random route: {A}",route.ToString());

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
        const bool recalculateEveryTime = true;
        int tempStepIterations = MaxIterations/1000;
        const int noChangeThreshold = 10000;
        double temperature = 1000;
        int stationA=0, stationB=0, oldCost, newCost, interSegmentIdx, interStationIdx;
        int swapFrom=0, swapTo=0;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();
        bool stopFlag = false;
        AnnealOpType operation;

        try
        {
            for (int i = 1; i < MaxIterations; i++)
            {
                nIterations++;
                // pick a random pair of stations to swap
                operation = PickRandomOperation(randomGenerator);

                oldCost = route.Cost;  // int is a value type so we don't have to worry about copy doing referencing things

                switch (operation)
                {
                    case AnnealOpType.SwapRandom:
                        do
                        {
                            stationA = randomGenerator.Next(0, route.Count);
                            stationB = randomGenerator.Next(0, route.Count);
                        } while (stationA == stationB); // don't swap station with itself
                    
                        net.Swap(ref route, stationA, stationB);
                        newCost = route.Cost;
                    
                        break;
                    case AnnealOpType.SwapIntermediate:
                        // If we pass by a station while going from A to B (ie. an Intermediate Station), it might be more efficient to move the station
                        // from its position in the route to between A and B
                    
                        // Find a segment which has nonzero number of Intermediate Stations
                        do
                        {
                            interSegmentIdx = randomGenerator.Next(0, route.IntermediateStations.Count);
                        } while (route.IntermediateStations[interSegmentIdx].Count == 0); // can't swap if there aren't intermediate stations
                    
                        // Pick a random station on this segment
                        // The stations where the segment starts and ends shouldn't be contained on this segment, so we can pick any station
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
                            Logger.Verbose("Swapping at same position... put a breakpoint here (iteration {A})", nIterations);
                        }

                        if (swapFrom == swapTo - 1)
                        {
                            Logger.Verbose("Swap will have no effect, station is already in right position (iteration {A})", nIterations);
                        }
                    
                        try
                        {
                            net.TakeAndInsert(ref route, swapFrom, swapTo);
                        }
                        catch (InvalidOperationException e)
                        {
                            Logger.Fatal("Tried to reinsert at the same position {A} (iteration number {B}). Exception {C}", swapFrom, nIterations, e);
                            throw new Exception();
                        }

                        if (recalculateEveryTime)
                        {
                            net.RecalculateRouteData(ref route);
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
                    Logger.Fatal("Cost of new route (iteration {A}) is negative!", nIterations);
                    switch (operation)
                    {
                        case AnnealOpType.SwapRandom:
                            Logger.Fatal("while swapping stations {A} and {B}", stationA, stationB);
                            break;
                        case AnnealOpType.SwapIntermediate:
                            Logger.Fatal("while takeInserting station {A} and inserting before station {B}", swapFrom,
                                swapTo);

                            break;
                        default:
                            Logger.Fatal("Unknown");
                            break;                  
                    }

                    Logger.Fatal("Cost before: {A} after: {B}", oldCost, newCost);
                    throw new NegativeCostException(newCost);
                }
            
                // strict solver feature: check cost function every iteration. 
                int calcCost = net.CostFunction(route);
                if (calcCost != route.Cost)
                {
                    Logger.Fatal("Cost mismatch! Calculated cost {A} but route cost is {B}",calcCost,route.Cost);
                    throw new CostMismatchException(calcCost, route.Cost);
                }

                if (AcceptSolution(oldCost, newCost, temperature, randomGenerator) && !stopFlag)
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
                            net.Swap(ref route, stationA, stationB);
                            break;
                        case AnnealOpType.SwapIntermediate:
                            if (swapFrom < swapTo)
                            {
                                net.TakeAndInsert(ref route, swapTo-1, swapFrom);
                            }
                            else
                            {
                                if (swapFrom < route.Count - 1)
                                {
                                    net.TakeAndInsert(ref route, swapTo, swapFrom + 1);
                                }
                                else
                                {
                                    net.TakeAndInsert(ref route, swapTo, swapFrom);
                                }
                            }

                            break;
                        default:
                            throw new InvalidOperationException("Invalid annealing operation type");
                    }

                    if (stopFlag)
                    {
                        Logger.Fatal("Route: {A}", string.Join(";", route.TargetStations));
                        Logger.Fatal("{A}", route.ToString());
                        throw new Exception("Error during solve!");
                    }
                    loopsSinceLastAccept++;
                }
            
                // cool down every tempStepIterations cycles to avoid cooling too fast
                if (i % tempStepIterations == 0)
                {
                    temperature *= CoolDownFactor;
                    Logger.Debug("Cooled down to {A}",temperature);
                    Logger.Debug("Current route: {A} (processing for {B} ms)",route.ToString(), perfTimer.ElapsedMilliseconds);
                }
            
                // if we haven't changed anything for a while then we're probably done
                if (loopsSinceLastAccept >= noChangeThreshold)
                {
                    Logger.Debug("No change for {A} iterations, stopping annealing",loopsSinceLastAccept);
                    break;
                }

                if (nIterations % (MaxIterations / 10) == 0)
                {
                    Logger.Information("{A} percent complete", nIterations*100 / (MaxIterations));
                }

                if (nIterations % (MaxIterations / 1000) == 0)
                {
                    ProgressCallback((nIterations / (double)MaxIterations)*100);
                }
            }
        }
        catch (Exception e)
        {
            
            Console.WriteLine(e);
            throw;
        }
        ProgressCallback(100); // always finish at 100% no matter when we finished
        Logger.Information("Final route: {A} (found in {B} ms, {C} ms per iteration)",route.ToString(), perfTimer.ElapsedMilliseconds, (perfTimer.ElapsedMilliseconds/(double)nIterations).ToString("0.####"));
        return route;
    }
}