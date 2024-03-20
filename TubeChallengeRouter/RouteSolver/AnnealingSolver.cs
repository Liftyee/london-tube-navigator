using System.Diagnostics;
using TransportNetwork;
using Serilog;

namespace RouteSolver;

public class AnnealingSolver : ISolver
{
    // Logger object given to the constructor, we will send output to it
    protected readonly ILogger Logger;
    
    // We call this callback during solving to update the UI with
    // the current progress state (e.g. to update a progress bar)
    protected readonly Action<double> ProgressCallback = (_) => { };
    
    // Configuration variables used in the annealing process. Not declared
    // const so the user can change them
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

    // Store types of annealing operations with an enum to make later code more interpretable.
    protected enum AnnealOpType
    {
        SwapRandom,
        SwapIntermediate,
        Transpose // currently not implemented
    }

    // Function that determines which operation the annealing algorithm
    // should perform. Override in future if more operations are implemented.
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

    // Main function to "solve" - generate an optimised route passing
    // through all nodes for a given network using Simulated Annealing.
    public virtual Route Solve(Network net)
    {
        // Reset progress (update progress bar to zero)
        ProgressCallback(0); 
        Logger.Information("Annealing route for {A}...", net.ToString());
        
        // Set up some performance tracking metrics
        Stopwatch perfTimer = Stopwatch.StartNew();
        int nIterations = 0;
        
        // Generate a random valid route as a starting point 
        Route route = net.GenerateRandomRoute();
        Logger.Debug("Random route: {A}",route.ToString());
        
        // This function lets me deduplicate the logic later
        // It determines whether we should accept the current solution
        // based on the Simulated Annealing algorithm's exponential formula
        static bool AcceptSolution(int oldCost,
            int newCost, double temperature, Random generator)
        {
            if (newCost < oldCost) return true; // just accept if it's better
            
            // accept the change with probability e^(-delta/T)
            double delta = oldCost - newCost;
            double probability = Math.Exp(delta / temperature);
            return generator.NextDouble() < probability;
        }
        
        // Constants for the Simulated Annealing process
        int tempStepIterations = MaxIterations/1000;
        const int noChangeThreshold = 1000; 
        double temperature = 1000; // Initial temperature
        int loopsSinceLastAccept = 0;
        Random prng = new Random(); // Pseudorandom number generator builtin
        
        for (int i = 1; i < MaxIterations; i++)
        {
            nIterations++;
            // pick a random pair of stations to swap
            AnnealOpType operation = PickRandomOperation(prng);

            int oldCost = route.Cost;

            int stationA;
            int stationB;
            int newCost;
            switch (operation)
            {
                case AnnealOpType.SwapRandom:
                    // Pick two different stations to swap
                    do
                    {
                        stationA = prng.Next(0, route.Count);
                        stationB = prng.Next(0, route.Count);
                    } while (stationA == stationB); 
                    
                    net.Swap(ref route, stationA, stationB);
                    newCost = route.Cost;
                    
                    break;
                case AnnealOpType.SwapIntermediate:
                    /* If we pass by a station while going from A to B
                       (ie. an Intermediate Station), it might be more
                       efficient to move the station from its position
                       in the route to between A and B */
                    
                    // Pick a random segment which has some Intermediate
                    // Stations (we can't swap if there are none)
                    int intSegIdx;
                    do
                    {
                        intSegIdx = prng.Next(0, route.InterStations.Count);
                    } while (route.InterStations[intSegIdx].Count == 0); 
                    
                    // Pick a random station on this segment
                    // The stations where the segment starts and ends
                    // shouldn't be contained in the InterStations list, so
                    // we can pick any station
                    int interStationIdx = 
                        prng.Next(0, route.InterStations[intSegIdx].Count);
                    string interStationId = 
                        route.InterStations[intSegIdx][interStationIdx]; 
                    
                    // Find the position of the chosen station in the target
                    // stations list
                    stationA = route.TargetStations.FindIndex(e => e == interStationId);
                    
                    // The station at the start of the segment has the same
                    // index as interSegmentIdx, so add one to get the end
                    // station of the segment
                    stationB = interStationIdx + 1;
                    
                    // Move the chosen station to between the two
                    // stations at the start and end of our segment
                    net.TakeAndInsert(ref route, stationA, stationB);
                    newCost = route.Cost;

                    break;
                case AnnealOpType.Transpose:
                    throw new NotImplementedException("Transpose operation not implemented");
                default:
                    throw new InvalidOperationException("Invalid annealing operation type");
            }
            
            // Determine whether we should accept the new solution
            if (AcceptSolution(oldCost, newCost, temperature, prng))
            {
                loopsSinceLastAccept = 0;
            }
            else
            {
                // Reject the change and revert the route's data
                route = RevertOperation(net, operation, route, stationA, stationB);
                loopsSinceLastAccept++;
            }
            
            // Cool down every tempStepIterations cycles (not too quickly)
            if (i % tempStepIterations == 0)
            {
                temperature *= CoolDownFactor;
                
                Logger.Debug("Cooled down to {A}",temperature);
                Logger.Debug("Current route: {A} (processing for {B} ms)",route.ToString(), perfTimer.ElapsedMilliseconds);
            }
            
            // If nothing's changed for a while then we're probably done
            if (loopsSinceLastAccept >= noChangeThreshold)
            {
                Logger.Debug("No change for {A} iterations, stopping annealing", loopsSinceLastAccept);
                break;
            }
            
            // Log a debug progress message every 10% iterations
            if (nIterations % (MaxIterations / 10) == 0)
            {
                Logger.Debug("{A} percent complete", Math.Ceiling(nIterations*100.0 / MaxIterations));
            }
            
            // Update the progress bar every 0.1% iterations
            if (nIterations % (MaxIterations / 1000) == 0)
            {
                ProgressCallback((nIterations / (double)MaxIterations)*100);
            }
        }
        // When we're finished always set the progress bar to 100%
        ProgressCallback(100); 
        Logger.Debug("Final route: {A} (found in {B} ms, {C} ms per iteration)",route.ToString(), perfTimer.ElapsedMilliseconds, (perfTimer.ElapsedMilliseconds/(double)nIterations).ToString("0.####"));
        
        // Reset the route's data for good measure
        net.RecalculateRouteData(ref route);
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