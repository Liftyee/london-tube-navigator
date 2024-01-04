using Serilog;
using TransportNetwork;
namespace RouteSolver;

public interface ISolver
{
    public Route Solve(Network network);
}