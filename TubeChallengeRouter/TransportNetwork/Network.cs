﻿using System.Text;
namespace TransportNetwork;
using Serilog;

public abstract class Network
{
    protected Dictionary<string, Station> Stations;
    protected Dictionary<int, Line> Lines;
    protected ILogger Logger;
    protected int NEdges;
    
    // A constant for cost comparisons, no cost should ever exceed this value.
    // Use 1 billion instead of MaxValue to avoid overflow issues
    protected const int InfCost = 1000000000;
    
    public Network(ILogger logger)
    {
        Logger = logger;
        Stations = new Dictionary<string, Station>();
        Lines = new Dictionary<int, Line>();
    }

    // Not used here, but other Networks inheriting from this class override
    // this procedure to perform preprocessing tasks after stations are added 
    internal virtual void Initialise()
    {
        
    }

    // Creates a station with given ID if that station is not already present
    public void AddStationId(string naptanId, string? name = null)
    {
        if (!HasStationById(naptanId)) // Do not add duplicate stations
        {
            // Use the ID-only constructor if we weren't given a name
            if (name is null)
            {
                Stations.Add(naptanId, new Station(naptanId));
            }
            else
            {
                Stations.Add(naptanId,new Station(naptanId, name));
            }
        }
    }
    
    // Link two stations with an edge, but leave the edge cost unpopulated.
    public void LinkStationsPartial(string startId, string endId, Dir direction, Line? line=null)
    {
        Station startStation = Stations[startId];
        Station endStation = Stations[endId];

        // Add links in both directions only if the link is bidirectional
        if (direction == Dir.Bidirectional)
        {
            startStation.AddLink(new Link(endStation, line, direction));
            endStation.AddLink(new Link(startStation, line, direction));
        } else {
            startStation.AddLink(new Link(endStation, line, direction));
        }
        
        NEdges++;
    }
    
    // For a station's link to another station, set the duration of the link
    public void UpdateLink(string startId, string endId, TimeSpan newTime)
    {
        Station startStation = Stations[startId];
        startStation.ModifyLink(endId, newTime);
    }

    // Is a station with the given ID present in the network?
    public bool HasStationById(string id)
    {
        return Stations.Keys.Contains(id);
    }
    
    // Give a human-readable summary of the network's properties
    public override string ToString()
    {
        return $"Network with {Stations.Count} stations and {Lines.Count} lines ({NEdges} directed edges)";
    }
    
    // Return list of all station IDs in the network
    public List<string> GetStationIDs()
    {
        return Stations.Keys.ToList();
    }

    // Function to calculate Cost (travel time) between two stations
    // Derived classes must implement an algorithm to do this
    public abstract int CostFunction(string startId, string endId, out List<string> path);

    public abstract int CostFunction(string startId, string endId);

    // Generate a random valid route (visiting all stations)
    public virtual Route GenerateRandomRoute()
    {
        // Our resulting list of target stations
        List<string> stationIDs = new List<string>(); 
        
        // The intermediate stations between each target station pair
        List<List<string>> intermediateStations = new List<List<string>>();
        
        // Track which stations we've visited in a set for O(1) lookups
        HashSet<string> visitedIDs = new HashSet<string>();
        
        // Our total cost of route (assumes cost = travel time in seconds)
        int totalCost = 0;
        
        // Just the count is enough to know whether we've visited all stations
        // Iterate until we have all the stations in our route
        while (visitedIDs.Count < Stations.Count)
        {
            // Pick a random station but only add it if we've not visited it yet
            string nextId = Stations.Keys.ElementAt(new Random().Next(Stations.Count));
            if (!visitedIDs.Contains(nextId))
            {
                stationIDs.Add(nextId);
                visitedIDs.Add(nextId);
                List<string> pathToNext;
                // Add the cost of the last two stations if this isn't the first
                if (visitedIDs.Count > 1)
                {
                    totalCost += CostFunction(stationIDs[^2], stationIDs[^1], out pathToNext);
                    intermediateStations.Add(pathToNext);
                }
            }
        }
        
        Route result = new Route(stationIDs, totalCost, intermediateStations);
        return result;
    }

    // Calculate the total cost function of a route
    public virtual int CostFunction(Route route)
    {
        int cost = 0;
        List<string> routeStations = route.GetTargetPath();
        for (int i = 0; i < routeStations.Count - 1; i++)
        {
            cost += CostFunction(routeStations[i], routeStations[i+1]);
        }

        return cost;
    }

    // convert route naptan IDs into a string for readability
    public string RouteToStringStationSeq(Route route)
    {
        StringBuilder output = new StringBuilder();
        List<string> stationIDs = route.GetTargetPath();
        for (int i = 0; i < stationIDs.Count(); i++)
        {
            output.Append($"{Stations[stationIDs[i]].Name.Replace(" Underground Station", "")}, ");
        }

        return output.ToString();
    }

    public void RouteDetailsToStream(Route route, Stream outStream)
    {
        using (StreamWriter writer = new StreamWriter(outStream))
        {
            writer.WriteLine("Route result computed at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ssZ"));
            writer.WriteLine($"Route with {route.Count} stations and length {route.Duration} minutes");
            
            List<string> stationIDs = route.GetTargetPath();
            List<List<string>> interStations = route.GetIntermediateStations();
            for (int i = 0; i < stationIDs.Count(); i++)
            {
                writer.WriteLine($"Visit: {Stations[stationIDs[i]].Name.Replace(" Underground Station", "")}");
                if (i < stationIDs.Count() - 1)
                {
                    writer.WriteLine(
                        $"Pass thru: {String.Join(", ", interStations[i].Select(s => Stations[s].Name.Replace(" Underground Station", "")))}");
                }
            }
            writer.WriteLine("Done");
        } 
    }
    
    // Swap the position of two stations in a route and update costs accordingly
    public virtual void Swap(ref Route route, int idxA, int idxB)
    {
        List<string> stations = route.GetTargetPath();
        
        int updatedCost = route.Cost;
        
        /* Instead of recalculating the travel time by summing all travel times
           between stations, we can just change the travel times to and from the
           stations that are being swapped. All other travel times should stay
           constant, so the only concern is our swapped stations. */
        
        // These four costs are the costs to travel to and from the
        // stations being swapped (before the swap)
        if (idxA > 0)             updatedCost -= CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost -= CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost -= CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost -= CostFunction(stations[idxB], stations[idxB + 1]);
        
        // Swap the positions of the stations in the route
        string temp = stations[idxA];
        stations[idxA] = stations[idxB];
        stations[idxB] = temp;
        
        // Now add the updated cost to travel to/from the newly swapped stations
        if (idxA > 0)             updatedCost += CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost += CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost += CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost += CostFunction(stations[idxB], stations[idxB + 1]);
        
        // update the route's cost 
        route.UpdateCost(updatedCost);
    }
    
    // Remove a station from one position and insert it so that it ends up in another.
    // The final position will be one before the index of the element at insertBefore
    // i.e. the element that was at that index gets pushed back to insert the new one.
    public virtual void TakeAndInsert(ref Route route, int takeFrom, int insertBefore)
    {
        throw new NotSupportedException(
            "TakeAndInsert not supported by Simple Network (use DijkstraCostNetwork instead)");
    }

    public void RecalculateRouteCosts(ref Route route)
    {
        route.UpdateCost(CostFunction(route));
    }

    // function to recalculate the intermediate stations of the route
    public void RecalculateRouteData(ref Route route)
    {
        List<string> stations = route.GetTargetPath();
        route.IntermediateStations.RemoveAll(_ => true); // clear the list of intermediate stations
        int totalCost = 0;
        for (int i = 0; i < stations.Count - 1; i++)
        {
            List<string> inter;
            totalCost += CostFunction(stations[i], stations[i + 1], out inter);
            route.IntermediateStations.Add(inter);
        }

        route.UpdateCost(totalCost);
    }
}