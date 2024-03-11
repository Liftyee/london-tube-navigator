using TransportNetwork;
namespace RouteSolver;

public interface ISolver
{
    public Route Solve(Network network);
    public void SetRandomSwapProbability(double prob);
    public double GetRandomSwapProbability();
    public void SetMaxIterations(int max);
    public int GetMaxIterations();
    public void SetCoolDownFactor(double factor);
    public double GetCoolDownFactor();
}