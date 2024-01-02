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
    
    public IRoute Solve(Network net)
    {
        Stopwatch perfTimer = Stopwatch.StartNew();
        // generate a random route
        IRoute route = net.GenerateRandomRoute();
        logger.Debug("Random route: {A}",route.ToString());

        Debug.Assert(route.Duration().TotalMinutes == net.CostFunction(route));

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
        const int maxIterations = 1000000;
        const double coolDownFactor = 0.99;
        const int noChangeThreshold = 10000;
        double Temperature = 1000;
        int randomA, randomB, oldCost, newCost;
        int loopsSinceLastAccept = 0;
        Random randomGenerator = new Random();

        for (int i = 1; i < maxIterations; i++)
        {
            // pick a random pair of stations to swap
            do
            {
                randomA = randomGenerator.Next(0, route.Count());
                randomB = randomGenerator.Next(0, route.Count());
            } while (randomA == randomB);

            oldCost = net.CostFunction(route);
            route.Swap(randomA, randomB);
            newCost = net.CostFunction(route);

            if (AcceptSolution(oldCost, newCost, Temperature, randomGenerator))
            {
                // accept the change
                loopsSinceLastAccept = 0;
                route.UpdateLength(newCost);
            }
            else
            {
                // reject the change (swap back)
                route.Swap(randomA, randomB);
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
        }
        logger.Debug("Final route: {A} (found in {B} ms)",route.ToString(), perfTimer.ElapsedMilliseconds);
        return route;
    }
}