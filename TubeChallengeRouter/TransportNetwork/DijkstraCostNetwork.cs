using System.Diagnostics;
using PriorityQueue;

namespace TransportNetwork;
using Serilog;

public class DijkstraCostNetwork : Network
{
    private readonly struct DijkstraNode : IComparable<DijkstraNode>
    {
        public readonly string StationId;
        public readonly int Cost;

        public int CompareTo(DijkstraNode other)
        {
            return Cost.CompareTo(other.Cost);
        }
        
        public DijkstraNode(string stationId, int cost)
        {
            StationId = stationId;
            Cost = cost;
        }
    }
    
    public DijkstraCostNetwork(ILogger logger) : base(logger)
    {
    }
    
    private Dictionary<string, Dictionary<string, int?>> _costCache;
    private Dictionary<string, Dictionary<string, List<string>>> _pathCache;

    // Override the base Network class's method to set up the cost cache
    internal override void Initialise()
    {
        // Initialise cost and path matrix to default values
        _costCache = new Dictionary<string, Dictionary<string, int?>>();
        _pathCache = new Dictionary<string, Dictionary<string, List<string>>>();
        foreach (string stationId in Stations.Keys)
        {
            _costCache[stationId] = new Dictionary<string, int?>();
            _pathCache[stationId] = new Dictionary<string, List<string>>();
            foreach (string station2Id in Stations.Keys)
            {
                if (stationId != station2Id)
                {
                    _costCache[stationId][station2Id] = null;
                }
                else
                {
                    _costCache[stationId][station2Id] = 0; // station has no cost to itself
                    _pathCache[stationId][station2Id] = new List<string>();
                }                    
            }
        }
    }
    
    // Function to return the minimum cost of a path between two stations
    // as well as the path itself, using cached results if possible
    // The path is returned by the out parameter "path"
    // Overrides and implements base class abstract method 
    public override int CostFunction(string startId, string endId, out List<string> path)
    {
        // if it's a direct path, just return nothing!
        if (Stations[startId].HasLink(endId))
        {
            path = new List<string>();
            return Stations[startId].CostTo(endId);
        }
        // first, lookup in cache to see if we have calculated it before
        // if it's in costCache, it should be in pathCache too
        if (_costCache[startId][endId] is not null)
        {
            path = _pathCache[startId][endId];
            return _costCache[startId][endId]!.Value;
        }
        
        // otherwise, calculate it and update the cache
        _costCache[startId][endId] = DijkstraLookup(startId, endId, out var result);
        _pathCache[startId][endId] = result;
        path = result;

        if (_costCache[startId][endId]!.Value < 0)
        {
            throw new InvalidDataException("Cost function is negative!");
        } 
        return _costCache[startId][endId]!.Value;
    }

    // Implement the simpler version of the CostFunction method too
    public override int CostFunction(string startId, string endId)
    {
        List<string> _ = new List<string>();
        return CostFunction(startId, endId, out _);
    }
    
    // Use Dijkstra's algorithm to find the shortest path between two 
    // stations. Return the cost of that path, and the path itself via the 
    // out parameter "path".
    private int DijkstraLookup(string startId, string endId, out List<string> path)
    {
        // If the start and end are the same, just return 0
        if (startId == endId)
        {
            path = new List<string>();
            return 0;
        }
        
        // Store the previous station which led to each station, to 
        // reconstruct the path
        Dictionary<string, string> prev = new();
        HashSet<string> visited = new(); // Use a HashSet for O(1) lookups
        
        // Priority queue for quick access to the least cost (next) station
        PriorityQueue<DijkstraNode>
            nextNodes = new PriorityQueue<DijkstraNode>(Stations.Count + 20, Priority.Smallest);
        
        // Prime the queue with our start station
        nextNodes.Insert(new DijkstraNode(startId, 0));
        
        // Initialise a dict to store the cost to each station
        Dictionary<string, int> dist = new();
        foreach (string stationId in Stations.Keys)
        {
            dist[stationId] = InfCost;
        }
        dist[startId] = 0;
        
        while (nextNodes.Count > 0)
        {
            DijkstraNode minCostNode = nextNodes.Pop();
            if (visited.Contains(minCostNode.StationId)) continue;
            foreach (Link link in Stations[minCostNode.StationId].GetLinks())
            {
                if (visited.Contains(link.Destination.NaptanId)) continue;
                int costToNeighbour = link.GetCost();
                int newCost = minCostNode.Cost + costToNeighbour;
                if (newCost < dist[link.Destination.NaptanId])
                {
                    dist[link.Destination.NaptanId] = newCost;
                    prev[link.Destination.NaptanId] = minCostNode.StationId;
                    nextNodes.Insert(new DijkstraNode(link.Destination.NaptanId, newCost));
                }
            }
            visited.Add(minCostNode.StationId);
            
            // If we're at the end, reconstruct the path and return
            if (minCostNode.StationId == endId)
            {
                // Get path by starting at the end and backtracking
                path = new();
                string? current = prev[endId];
                while (current != startId)
                {
                    path.Add(current);
                    current = prev[current];
                }
                path.Reverse(); // We backtracked, so reverse the list
                return minCostNode.Cost;
            }
        }
        // If there is a path between the stations, we should never get here
        Logger.Error("Dijkstra: No more stations to visit!");
        throw new ArgumentException($"No route found between {startId} and {endId}");
    }
    
    // Override base class method so the intermediates are updated properly
    public override void Swap(ref Route route, int idxA, int idxB)
    {
        List<string> stations = route.TargetStations;
        
        int updatedCost = route.Cost;
        int maxIdx = route.Count - 1;
        
        // These four costs are the costs to travel to and from the
        // stations being swapped (before the swap)
        if (idxA > 0)      updatedCost -= CostFunction(route, idxA-1, idxA);
        if (idxA < maxIdx) updatedCost -= CostFunction(route, idxA, idxA+1);
        if (idxB > 0)      updatedCost -= CostFunction(route, idxB - 1, idxB);
        if (idxB < maxIdx) updatedCost -= CostFunction(route, idxB, idxB + 1);
        
        // Swap the stations in the route
        string temp = stations[idxA];
        stations[idxA] = stations[idxB];
        stations[idxB] = temp;
        
        // Now add the updated cost to travel to/from the swapped stations
        if (idxA > 0)      updatedCost += UpdatePath(route, idxA);
        if (idxA < maxIdx) updatedCost += UpdatePath(route, idxA + 1);
        if (idxB > 0)      updatedCost += UpdatePath(route, idxB);
        if (idxB < maxIdx) updatedCost += UpdatePath(route, idxB + 1);
        
        route.UpdateCost(updatedCost);
    }
    
    // Remove a station from one position and insert it so that it ends up in
    // another. The final position will be just before the index of the
    // station at insertBefore i.e. the element that was at that index
    // gets pushed back in the list to insert the new one.
    public override void TakeAndInsert(ref Route route, int takeFrom, int insertBefore)
    {
        // If the two indices are the same, our operation will have no effect
        // so just return early.
        if (insertBefore == takeFrom)
        {
            return;
        }
        List<string> stns = route.TargetStations;
        int updatedCost = route.Cost;
        string station = route.TargetStations[takeFrom];
        
        // Subtract travel cost to and from the station we are removing
        if (takeFrom > 0)
        {
            updatedCost -= CostFunction(stns[takeFrom - 1], stns[takeFrom]);
        }

        if (takeFrom < route.Count - 1)
        {
            updatedCost -= CostFunction(stns[takeFrom], stns[takeFrom + 1]);
        }
        
        // also subtract travel cost between the stations we will be
        // inserting between, to get ready for inserting the moved station
        if (insertBefore > 0)
        {
            updatedCost -= CostFunction(stns[insertBefore - 1], stns[insertBefore]);
        }
        route.TargetStations.RemoveAt(takeFrom);
        Logger.Verbose("Yoinked station {A}", station);
        
        // If our target index to insert at is after the index we are 
        // removing from, removing will shift the indices so we need to 
        // subtract one so the final index is between the right elements
        int actualInsertPos;
        if (insertBefore > takeFrom)
        {
            actualInsertPos = insertBefore - 1;
        }
        else
        {
            actualInsertPos = insertBefore;
        }

        route.TargetStations.Insert(actualInsertPos, station);
        
        // update our copy of the stations list 
        stns = route.TargetStations;

        // add back the new travel cost to and from the station we inserted
        // indices differ depending on whether we inserted in front or behind
        if (insertBefore > takeFrom)
        {
            if (insertBefore > 0)
            {
                updatedCost += UpdatePath(route, insertBefore);
            }
            
            if (insertBefore > 1)
            {
                updatedCost += UpdatePath(route, insertBefore-1);
            }
            
            if (takeFrom > 0)
            {
                updatedCost += UpdatePath(route, takeFrom);
            }
        }
        else
        {
            if (insertBefore > 0)
            {
                updatedCost += UpdatePath(route, insertBefore);
            }
        
            if (insertBefore < route.Count-1)
            {
                updatedCost += UpdatePath(route, insertBefore+1);
            }

            if (takeFrom < route.Count-1)
            {
                updatedCost += UpdatePath(route, takeFrom);
            }

        }
   
        route.UpdateCost(updatedCost);
        Logger.Verbose("Route is {A}", route.ToString());
    }

    /* Function to update the intermediate station path between two stations
       A and B, where B is the station at index idxA in the route and A 
       is at idxA-1. Returns the cost of the new path.
       Deduplicates code in Swap() and TakeInsert() functions */
    private int UpdatePath(Route route, int idxA)
    {
        List<string> newpath;
        int cost = CostFunction(route.TargetStations[idxA - 1], route.TargetStations[idxA], out newpath);
        route.InterStations[idxA - 1] = newpath;
        return cost;
    }
}