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
        int randomA, randomB, oldCost, newCost;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();

        for (int i = 1; i < maxIterations; i++)
        {
            nIterations++;
            // pick a random pair of stations to swap
            // TODO: implement "swap intermediate" action
            do
            {
                randomA = randomGenerator.Next(0, route.Count);
                randomB = randomGenerator.Next(0, route.Count);
            } while (randomA == randomB);

            oldCost = route.Cost; // int is a value type so we don't have to worry about copying
            net.Swap(route, randomA, randomB);
            newCost = route.Cost;

            if (AcceptSolution(oldCost, newCost, Temperature, randomGenerator))
            {
                // accept the change (duration has already been updated by the swap)
                loopsSinceLastAccept = 0;
            }
            else
            {
                // reject the change (swap back)
                net.Swap(route, randomA, randomB);
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