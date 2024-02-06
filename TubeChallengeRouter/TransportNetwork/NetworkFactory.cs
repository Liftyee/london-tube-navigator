namespace TransportNetwork;
using Serilog;

public enum NetworkType
{
    Simple,
    Floyd,
    Dijkstra
}

public class NetworkFactory
{
    private INetworkDataSource _dataSource;
    public NetworkFactory(INetworkDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public Network Generate(NetworkType type, ILogger logger)
    {
        Network result;
        switch (type)
        {
            case NetworkType.Simple:
                throw new NotSupportedException("Simple network is an abstract class and cannot be instantiated");
            case NetworkType.Floyd:
                result = new FloydCostNetwork(logger);
                break;
            case NetworkType.Dijkstra:
                result = new DijkstraCostNetwork(logger);
                break;
            default:
                throw new NotSupportedException("Network type given not supported");
        }
        
        _dataSource.PopulateNetworkStructure(ref result);
        result.Initialise();
        return result;
    }
}
