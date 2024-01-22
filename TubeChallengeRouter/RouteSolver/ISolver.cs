using Serilog;
using TransportNetwork;
namespace RouteSolver;

public interface ISolver
{
    public Route Solve(Network network);
    public void SetRandomSwapProbability(double prob);
}