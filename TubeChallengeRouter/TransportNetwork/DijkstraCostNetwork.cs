namespace TransportNetwork;
using Serilog;

public class DijkstraCostNetwork : Network
{
    private Dictionary<string, Dictionary<string, int?>> _costCache;
    
    public DijkstraCostNetwork(ILogger logger) : base(logger)
    {
    }

    internal override void Initialise()
    {
        // initialise cost matrix to all null's
        _costCache = new Dictionary<string, Dictionary<string, int?>>();
        foreach (string stationID in _stations.Keys)
        {
            _costCache[stationID] = new Dictionary<string, int?>();
            foreach (string station2ID in _stations.Keys)
            {
                if (stationID != station2ID)
                {
                    _costCache[stationID][station2ID] = null;
                }
                else
                {
                    _costCache[stationID][station2ID] = 0; // station has no cost to itself
                }
            }
        }
    }
    public override int CostFunction(string startId, string endId)
    {
        // first, lookup in cache to see if we have calculated it before
        if (_costCache[startId][endId] is not null)
        {
            return _costCache[startId][endId].Value;
        }
        
        // otherwise, calculate it and update the cache
        _costCache[startId][endId] = DijkstraLookup(startId, endId);
        throw new NotImplementedException("Implement Dijkstra first");
    }

    private int DijkstraLookup(string startId, string endId)
    {
        throw new NotImplementedException("Implement Dijkstra algorithm here using my prio queue algo");
    }
}