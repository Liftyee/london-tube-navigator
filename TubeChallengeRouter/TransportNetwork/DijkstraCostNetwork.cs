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
    private Dictionary<string, Dictionary<string, List<string>>> _pathCache;
    
    public DijkstraCostNetwork(ILogger logger) : base(logger)
    {
    }

    internal override void Initialise()
    {
        // initialise cost matrix to all null's
        _costCache = new Dictionary<string, Dictionary<string, int?>>();
        _pathCache = new Dictionary<string, Dictionary<string, List<string>>>();
        foreach (string stationID in Stations.Keys)
        {
            _costCache[stationID] = new Dictionary<string, int?>();
            _pathCache[stationID] = new Dictionary<string, List<string>>();
            foreach (string station2ID in Stations.Keys)
            {
                if (stationID != station2ID)
                {
                    _costCache[stationID][station2ID] = null;
                }
                else
                {
                    _costCache[stationID][station2ID] = 0; // station has no cost to itself
                }                    
                // _pathCache[stationID][station2ID] = new List<string>();
            }
        }
    }
    public override int CostFunction(string startId, string endId, out List<string> path)
    {
        // if it's a direct path, just return nothing!
        if (Stations[startId].HasLink(endId))
        {
            path = new List<string>();
            return Stations[startId].CostTo(endId);
        }
        // first, lookup in cache to see if we have calculated it before
        if (_costCache[startId][endId] is not null)
        {
            path = _pathCache[startId][endId];
            return _costCache[startId][endId].Value;
        }
        
        // otherwise, calculate it and update the cache
        List<string> result;
        _costCache[startId][endId] = DijkstraLookup(startId, endId, out result);
        _pathCache[startId][endId] = result; // TODO: might induce undesired referencing? 
        path = result;
        return _costCache[startId][endId].Value;
    }

    public override int CostFunction(string startId, string endId)
    {
        List<string> _ = new List<string>();
        return CostFunction(startId, endId, out _);
    }

    private int DijkstraLookup(string startId, string endId, out List<string> path)
    {
        Dictionary<string, string> prev = new();
        PriorityQueue<DijkstraNode>
            nextNodes = new PriorityQueue<DijkstraNode>(Stations.Count + 20, Priority.Smallest);
        nextNodes.Insert(new DijkstraNode(startId, 0));
        HashSet<string> visited = new();
        Dictionary<string, int> dist = new();
        foreach (string stationId in Stations.Keys)
        {
            dist[stationId] = INF_COST;
        }
        dist[startId] = 0;
        
        while (nextNodes.Count > 0)
        {
            DijkstraNode minCostNode = nextNodes.Pop();
            foreach (Link link in Stations[minCostNode.StationID].GetLinks())
            {
                if (visited.Contains(link.Destination.NaptanId)) continue;
                int costToNeighbour = link.GetCost();
                int newCost = minCostNode.Cost + costToNeighbour;
                if (newCost < dist[link.Destination.NaptanId])
                {
                    dist[link.Destination.NaptanId] = newCost;
                    prev[link.Destination.NaptanId] = minCostNode.StationID;
                    nextNodes.Insert(new DijkstraNode(link.Destination.NaptanId, newCost));
                }
            }
            visited.Add(minCostNode.StationID);
            if (minCostNode.StationID == endId)
            {
                // reconstruct path
                List<string> result = new();
                string? current = prev[endId];
                while (current != startId)
                {
                    result.Add(current);
                    current = prev[current];
                }
                result.Reverse();
                path = result;
                return minCostNode.Cost;
            }
        }
        Logger.Debug("No more stations to visit");
        // TODO: make a custom exception
        throw new ArgumentException($"No route found between {startId} and {endId}");
    }
    
    public override void Swap(Route route, int idxA, int idxB)
    {
        List<string> stations = route.GetTargetPath();
        
        TimeSpan updatedTime = route.Duration;
        int updatedCost = route.Cost;
        
        /* Instead of recalculating the travel time by summing all travel times between stations, we can just
           change the travel times to and from the stations that are being swapped. All other travel times should
           remain constant, so we are only concerned with what happens around our swapped stations. */
        
        // These four times are the time taken to travel to and from both stations being swapped (before the swap)
        if (idxA > 0)             updatedTime -= TravelTime(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedTime -= TravelTime(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedTime -= TravelTime(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedTime -= TravelTime(stations[idxB], stations[idxB + 1]);

        // Do the same for costs (unitless value considering but not limited to duration)
        if (idxA > 0)             updatedCost -= CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost -= CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost -= CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost -= CostFunction(stations[idxB], stations[idxB + 1]);
        
        // swap the stations in the route
        string temp = stations[idxA];
        stations[idxA] = stations[idxB];
        stations[idxB] = temp;
        
        // Now add the updated times to travel to and from the swapped stations in their new position
        if (idxA > 0)             updatedTime += TravelTime(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedTime += TravelTime(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedTime += TravelTime(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedTime += TravelTime(stations[idxB], stations[idxB + 1]);
        
        // and costs too
        if (idxA > 0)               updatedCost += UpdatePathReturnCost(route, idxA);
        if (idxA < route.Count - 1) updatedCost += UpdatePathReturnCost(route, idxA + 1);
        if (idxB > 0)               updatedCost += UpdatePathReturnCost(route, idxB);
        if (idxB < route.Count - 1) updatedCost += UpdatePathReturnCost(route, idxB + 1);
        
        // update the route's length (time taken)
        route.UpdateDuration(updatedTime);
        
        // update the route's cost (unitless value based on number of factors)
        route.UpdateCost(updatedCost);
    }
    
    // Remove a station from one position and insert it so that it ends up in another.
    // The final position will be one before the index of the element at insertBefore
    // i.e. the element that was at that index gets pushed back to insert the new one.
    public override void TakeAndInsert(Route route, int takeFrom, int insertBefore)
    {
        List<string> stations = route.GetTargetPath();

        TimeSpan updatedTime = route.Duration;
        int updatedCost = route.Cost;

        string station = route.TargetStations[takeFrom];
        
        // subtract travel cost to and from the station we are removing
        if (takeFrom > 0)
        {
            updatedTime -= TravelTime(stations[takeFrom - 1], stations[takeFrom]);
            updatedCost -= CostFunction(stations[takeFrom - 1], stations[takeFrom]);
        }

        if (takeFrom < route.Count - 1)
        {
            updatedTime -= TravelTime(stations[takeFrom], stations[takeFrom + 1]);
            updatedCost -= CostFunction(stations[takeFrom], stations[takeFrom + 1]);
        }
        
        // also subtract travel cost between the stations we will be inserting between, to get ready for insert
        if (insertBefore > 0)
        {
            updatedTime -= TravelTime(stations[insertBefore - 1], stations[insertBefore]);
            updatedCost -= CostFunction(stations[insertBefore - 1], stations[insertBefore]);
        }
        route.TargetStations.RemoveAt(takeFrom);
        
        // if the indices are the same, we might need to subtract
        // we should never be doing this anyways, so throw an exception
        if (insertBefore == takeFrom)
        {
            throw new InvalidOperationException("Why are you taking and reinserting at the same place?");
        }
        
        // if the index we are going to insert at is after the index we are removing from, we need to subtract one
        // so the final index in the array is between the elements we want TODO: rewrite this comment
        if (insertBefore > takeFrom)
        {
            insertBefore--;
        }

        route.TargetStations.Insert(insertBefore, station);
        
        // update our copy of the stations list 
        // stations = route.GetTargetPath(); (wait we don't need to??)
        // TODO: this is sus, is the unit test SwapInsert_UpdatesCost wrong?
        
        // add back the new travel cost to and from the station we inserted
        if (insertBefore > 0)
        {
            updatedTime += TravelTime(stations[insertBefore - 1], stations[insertBefore]);
            updatedCost += UpdatePathReturnCost(route, insertBefore);
        }
        
        if (insertBefore < route.Count-1)
        {
            updatedTime += TravelTime(stations[insertBefore], stations[insertBefore+1]);
            updatedCost += UpdatePathReturnCost(route, insertBefore+1);
        }

        if (takeFrom > 0)
        {
            updatedTime += TravelTime(stations[takeFrom - 1], stations[takeFrom]);
            updatedCost += UpdatePathReturnCost(route, takeFrom);
        }
        
        route.UpdateDuration(updatedTime);
        route.UpdateCost(updatedCost);
    }

    // Function to update the intermediate station path of an indexed segment of a Route
    // Deduplicates code in Swap() and TakeInsert() functions
    private int UpdatePathReturnCost(Route route, int idxA)
    {
        List<string> newpath;
        int cost = CostFunction(route.TargetStations[idxA - 1], route.TargetStations[idxA], out newpath);
        route.IntermediateStations[idxA - 1] = newpath;
        return cost;
    }
}