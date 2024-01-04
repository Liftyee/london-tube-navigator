using PriorityQueue;

namespace TransportNetwork;
using Serilog;

public class DijkstraCostNetwork : Network
{
    private readonly struct DijkstraNode : IComparable<DijkstraNode>
    {
        public readonly string StationID;
        public readonly int Cost;

        public int CompareTo(DijkstraNode other)
        {
            return Cost.CompareTo(other.Cost);
        }
        
        public DijkstraNode(string stationID, int cost)
        {
            StationID = stationID;
            Cost = cost;
        }
    }
    
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
        if (_stations[startId].HasLink(endId))
        {
            return _stations[startId].CostTo(endId);
        }
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
        Dictionary<string, string> prev = new();
        PriorityQueue<DijkstraNode>
            nextNodes = new PriorityQueue<DijkstraNode>(_stations.Count + 20, Priority.Smallest);
        nextNodes.Insert(new DijkstraNode(startId, 0));
        while (nextNodes.Count > 0)
        {
            DijkstraNode minCostNode = nextNodes.Pop();
            if (minCostNode.StationID == endId)
            {
                return minCostNode.Cost;
            }
            foreach (Link link in _stations[minCostNode.StationID].GetLinks())
            {
                int costToNeighbour = link.GetCost();
                int newCost = minCostNode.Cost + costToNeighbour;
                if (_costCache[minCostNode.StationID][link.Destination.NaptanId] is null ||
                    newCost < _costCache[minCostNode.StationID][link.Destination.NaptanId])
                {
                    _costCache[minCostNode.StationID][link.Destination.NaptanId] = newCost;
                    prev[link.Destination.NaptanId] = minCostNode.StationID;
                    nextNodes.Insert(new DijkstraNode(link.Destination.NaptanId, newCost));
                }
            }
        }
        // TODO: make a custom exception
        throw new ArgumentException($"No route found between {startId} and {endId}");
    }
}