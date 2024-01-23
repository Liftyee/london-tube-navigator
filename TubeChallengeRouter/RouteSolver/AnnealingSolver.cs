using System.Diagnostics;
using TransportNetwork;
using Serilog;

namespace RouteSolver;

public class AnnealingSolver : ISolver
{
    protected readonly ILogger Logger;
    protected readonly Action<double> ProgressCallback = (_) => { };
    private double _randomSwapProbability;
    protected int MaxIterations;
    protected double CoolDownFactor;
    
    public AnnealingSolver(ILogger logger)
    {
        this.Logger = logger;
        _randomSwapProbability = 1;
        CoolDownFactor = 0.99;
        MaxIterations = 5000000;
    }
    
    public AnnealingSolver(ILogger logger, Action<double> progressCallback) : this(logger)
    {
        this.ProgressCallback = progressCallback;
    }

    protected enum AnnealOpType
    {
        SwapRandom,
        SwapIntermediate,
        Transpose
    }

    protected AnnealOpType PickRandomOperation(Random generator)
    {
        if (generator.NextDouble() < _randomSwapProbability)
        {
            return AnnealOpType.SwapRandom;
        }
        else
        {
            return AnnealOpType.SwapIntermediate;
        }
    }

    public virtual Route Solve(Network net)
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
        const bool allowNegativeContinue = true;
        const bool recalculateEveryTime = true;
        int tempStepIterations = MaxIterations/1000;
        const int noChangeThreshold = 10000;
        double temperature = 1000;
        int stationA=0, stationB=0, oldCost, newCost, interSegmentIdx, interStationIdx;
        int swapFrom=0, swapTo=0;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();
        bool stopFlag = false;
        
        for (int i = 1; i < MaxIterations; i++)
        {
            nIterations++;
            // pick a random pair of stations to swap
            AnnealOpType operation = PickRandomOperation(randomGenerator);

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
                if (allowNegativeContinue)
                {
                    Logger.Warning("Cost of new route (iteration {A}) is negative!", nIterations);
                    Logger.Warning("Allowing post-negative continue, Let's pretend that never happened...");
                    Logger.Warning("Recalculating route data...");
                    net.RecalculateRouteData(ref route);
                }
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
                    throw new Exception("Cost is negative!");
                }
                loopsSinceLastAccept++;
            }
            
            // cool down every tempStepIterations cycles to avoid cooling too fast
            if (i % tempStepIterations == 0)
            {
                temperature *= CoolDownFactor;
                
                Logger.Debug("Cooled down to {A}",temperature);
                Logger.Debug("Current route: {A} (processing for {B} ms)",route.ToString(), perfTimer.ElapsedMilliseconds);
                int calcCost = net.CostFunction(route);
                if (calcCost != route.Cost)
                {
                    Logger.Fatal("Cost mismatch! Calculated cost {A} but route cost is {B}",calcCost,route.Cost);
                    throw new Exception("Cost mismatch!");
                }
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
        ProgressCallback(100); // always finish at 100% no matter when we finished
        Logger.Information("Final route: {A} (found in {B} ms, {C} ms per iteration)",route.ToString(), perfTimer.ElapsedMilliseconds, (perfTimer.ElapsedMilliseconds/(double)nIterations).ToString("0.####"));
        return route;
    }
    
    public void SetRandomSwapProbability(double probability)
    {
        if (probability < 0 || probability > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(probability),"Probability must be between 0 and 1");
        }
        _randomSwapProbability = probability;
    }
    
    public double GetRandomSwapProbability()
    {
        return _randomSwapProbability;
    }

    public void SetMaxIterations(int max)
    {
        MaxIterations = max;
    }

    public int GetMaxIterations()
    {
        return MaxIterations;
    }
    
    public void SetCoolDownFactor(double factor)
    {
        if (factor < 0 || factor > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(factor),"Cool down factor must be between 0 and 1");
        }
        CoolDownFactor = factor;
    }
    
    public double GetCoolDownFactor()
    {
        return CoolDownFactor;
    }
    
    protected class NegativeCostException : ApplicationException
    {
        public NegativeCostException(int cost) : base($"Cost of route is negative ({cost})")
        {
            
        }
    }

    protected class CostMismatchException : ApplicationException
    {
        public CostMismatchException(int calculatedCost, int routeCost) : base($"Calculated cost ({calculatedCost}) does not match route cost ({routeCost})")
        {
            
        }
    }

}