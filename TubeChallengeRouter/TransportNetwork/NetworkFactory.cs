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
    private INetworkDataFetcher _dataSource;
    public NetworkFactory(INetworkDataFetcher dataSource)
    {
        _dataSource = dataSource;
    }

    public Network Generate(NetworkType type, ILogger logger)
    {
        Network result;
        switch (type)
        {
            case NetworkType.Simple:
                result = new Network(logger);
                break;
            case NetworkType.Floyd:
                result = new FloydCostNetwork(logger);
                break;
            case NetworkType.Dijkstra:
                result = new DijkstraCostNetwork(logger);
                break;
            default:
                throw new NotImplementedException();
        }
        
        _dataSource.PopulateNetworkStructure(ref result);
        result.Initialise();
        return result;
    }
}
