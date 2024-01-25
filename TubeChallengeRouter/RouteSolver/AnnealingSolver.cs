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
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();
        
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
                    stationA = route.TargetStations.FindIndex(e => e == interStationId);
                    
                    // the station at the start of the segment has the same index as interSegmentIdx, so add one to get
                    // the end station of the segment
                    stationB = interStationIdx + 1;
                    
                    try
                    {
                        net.TakeAndInsert(ref route, stationA, stationB);
                    }
                    catch (InvalidOperationException e)
                    {
                        Logger.Fatal("Tried to reinsert at the same position {A} (iteration number {B}). Exception {C}", stationA, nIterations, e);
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

            if (AcceptSolution(oldCost, newCost, temperature, randomGenerator))
            {
                // accept the change (duration and cost have already been updated by the operation)
                loopsSinceLastAccept = 0;
            }
            else
            {
                // reject the change (swap back)
                route = RevertOperation(net, operation, route, stationA, stationB);
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
        ProgressCallback(100); // always finish at 100% no matter when we finished
        Logger.Information("Final route: {A} (found in {B} ms, {C} ms per iteration)",route.ToString(), perfTimer.ElapsedMilliseconds, (perfTimer.ElapsedMilliseconds/(double)nIterations).ToString("0.####"));
        return route;
    }

    private static Route RevertOperation(Network net, AnnealOpType operation, Route route, int stationA, int stationB)
    {
        switch (operation)
        {
            case AnnealOpType.SwapRandom:
                net.Swap(ref route, stationA, stationB);
                break;
            case AnnealOpType.SwapIntermediate:
                if (stationA < stationB)
                {
                    net.TakeAndInsert(ref route, stationB-1, stationA);
                }
                else
                {
                    if (stationA < route.Count - 1)
                    {
                        net.TakeAndInsert(ref route, stationB, stationA + 1);
                    }
                    else
                    {
                        net.TakeAndInsert(ref route, stationB, stationA);
                    }
                }

                break;
            default:
                throw new InvalidOperationException("Invalid annealing operation type");
        }

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