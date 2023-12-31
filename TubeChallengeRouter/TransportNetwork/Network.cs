﻿using System.Text;
namespace TransportNetwork;
using Serilog;

[Serializable]
public class Network
{
    protected Dictionary<string, Station> Stations;
    protected Dictionary<int, Line> Lines;
    protected ILogger Logger;
    protected const int INF_COST = 1000000000; // use 1 billion instead of MaxValue to avoid overflow issues
    public int StationCount => Stations.Count;
    protected int NEdges;
    
    public Network(ILogger logger)
    {
        this.Logger = logger;
        Stations = new Dictionary<string, Station>();
        Lines = new Dictionary<int, Line>();
    }

    internal virtual void Initialise()
    {
        
    }

    public void AddStation(Station stationToAdd)
    {
        Stations.Add(stationToAdd.NaptanId, stationToAdd);
    }

    public void AddStationByIdIfNotPresent(string naptanId)
    {
        if (!this.HasStationById(naptanId))
        {
            this.AddStation(new Station(naptanId));
        }
    }

    public void AddStationByIdIfNotPresent(string naptanId, string name)
    {
        if (!this.HasStationById(naptanId))
        {
            this.AddStation(new Station(naptanId, name));
        }
    }
    
    public void LinkStationsPartial(string startId, string endId, Dir direction, Line? line=null)
    {
        Station startStation = Stations[startId];
        Station endStation = Stations[endId];
        startStation.AddLink(new Link(startStation, endStation, line, direction));
        NEdges++;
    }
    
    public void UpdateLink(string startId, string endId, TimeSpan newTime)
    {
        Station startStation = Stations[startId];
        startStation.ModifyLink(endId, newTime);
    }

    public bool HasStationById(string ID)
    {
        return Stations.Keys.Contains(ID);
    }
    
    public override string ToString()
    {
        return $"Network with {Stations.Count} stations and {Lines.Count} lines ({NEdges} directed edges)";
    }

    public string EnumerateStations()
    {
        // output each station and its links
        StringBuilder output = new StringBuilder();
        foreach (KeyValuePair<string, Station> station in Stations)
        {
            output.Append($"Station {station.Key} has links to: ");
            foreach (Link link in station.Value.GetLinks())
            {
                output.Append($"{link.Destination.NaptanId} ({link.Duration.ToString()}) {link.Dir.ToString()}, ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }

    public virtual int CostFunction(string startId, string endId, List<string>? path=null)
    {
        if (Stations[startId].HasLink(endId))
        {
            return (int)Stations[startId].GetLinkByDestId(endId).Duration.TotalSeconds;
        }
        else
        {
            throw new ArgumentException("Simple network doesn't support cost function for non-linked stations (use overrides)");
        }
    }

    // generate random route through all stations
    public virtual Route GenerateRandomRoute()
    {
        List<string> stationIDs = new List<string>(); 
        HashSet<string> visitedIDs = new HashSet<string>();
        int totalCost = 0;
        List<List<string>> intermediateStations = new List<List<string>>();
        
        while (visitedIDs.Count < Stations.Count)
        {
            string nextID = Stations.Keys.ElementAt(new Random().Next(Stations.Count));
            if (!visitedIDs.Contains(nextID))
            {
                stationIDs.Add(nextID);
                visitedIDs.Add(nextID);
                List<string> pathToNext = new List<string>();
                if (visitedIDs.Count > 1)
                {
                    totalCost += CostFunction(stationIDs[^2], stationIDs[^1], pathToNext);
                }
                intermediateStations.Add(pathToNext);
            }
        }
        
        Route result = new Route(stationIDs, new TimeSpan(0, 0, totalCost), totalCost, intermediateStations);

        return result;
    }

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

    public virtual TimeSpan TravelTime(Route route)
    {
        return new TimeSpan(0,0,CostFunction(route));
    }
    
    public virtual TimeSpan TravelTime(string startId, string endId)
    {
        return new TimeSpan(0,0,CostFunction(startId, endId));
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
    
    public virtual void Swap(Route route, int idxA, int idxB)
    {
        List<string> stations = route.GetTargetPath();
        List<List<string>> interStations = route.GetIntermediateStations();
        
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
        if (idxA > 0)             updatedCost += CostFunction(stations[idxA - 1], stations[idxA], interStations[idxA-1]);
        if (idxA < route.Count-1) updatedCost += CostFunction(stations[idxA], stations[idxA + 1], interStations[idxA]);
        if (idxB > 0)             updatedCost += CostFunction(stations[idxB - 1], stations[idxB], interStations[idxB-1]);
        if (idxB < route.Count-1) updatedCost += CostFunction(stations[idxB], stations[idxB + 1], interStations[idxB]);
        
        // update the route's length (time taken)
        route.UpdateDuration(updatedTime);
        
        // update the route's cost (unitless value based on number of factors)
        route.UpdateCost(updatedCost);
    }
}