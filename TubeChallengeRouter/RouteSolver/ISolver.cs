using Serilog;
using TransportNetwork;
namespace RouteSolver;

public interface ISolver
{
    public IRoute Solve(Network network);
}