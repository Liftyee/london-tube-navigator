using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Serilog.Debugging;
using System.Collections.Specialized;

namespace TransportNetwork;
using IO.Swagger.Model;
using Serilog;

[Serializable]
public class Network
{
    protected Dictionary<string, Station> _stations;
    protected Dictionary<int, Line> _lines;
    protected ILogger logger;
    protected const int INF_COST = 1000000000; // use 1 billion instead of MaxValue to avoid overflow issues
    public int StationCount => _stations.Count;
    protected int nEdges;
    
    public Network(ILogger logger)
    {
        this.logger = logger;
        _stations = new Dictionary<string, Station>();
        _lines = new Dictionary<int, Line>();
    }

    internal virtual void Initialise()
    {
        
    }

    public void AddStation(Station stationToAdd)
    {
        _stations.Add(stationToAdd.NaptanId, stationToAdd);
    }

    public void AddStationByIdIfNotPresent(string naptanId)
    {
        if (!this.HasStationByID(naptanId))
        {
            this.AddStation(new Station(naptanId));
        }
    }

    public void AddStationByIdIfNotPresent(string naptanId, string name)
    {
        if (!this.HasStationByID(naptanId))
        {
            this.AddStation(new Station(naptanId, name));
        }
    }
    
    public void LinkStationsPartial(string startId, string endId, Dir direction, Line? line=null)
    {
        Station startStation = _stations[startId];
        Station endStation = _stations[endId];
        startStation.AddLink(new Link(startStation, endStation, line, direction));
        nEdges++;
    }
    
    public void UpdateLink(string startId, string endId, TimeSpan newTime)
    {
        Station startStation = _stations[startId];
        startStation.ModifyLink(endId, newTime);
    }

    public bool HasStationByID(string ID)
    {
        return _stations.Keys.Contains(ID);
    }
    
    public override string ToString()
    {
        return $"Network with {_stations.Count} stations and {_lines.Count} lines ({nEdges} directed edges)";
    }

    public string EnumerateStations()
    {
        // output each station and its links
        StringBuilder output = new StringBuilder();
        foreach (KeyValuePair<string, Station> station in _stations)
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

    public virtual int CostFunction(string startId, string endId)
    {
        if (_stations[startId].HasLink(endId))
        {
            return (int)_stations[startId].GetLinkByDestId(endId).Duration.Value.TotalSeconds;
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
        int cost = 0;
        
        while (visitedIDs.Count < _stations.Count)
        {
            string nextID = _stations.Keys.ElementAt(new Random().Next(_stations.Count));
            if (!visitedIDs.Contains(nextID))
            {
                stationIDs.Add(nextID);
                visitedIDs.Add(nextID);
                if (visitedIDs.Count > 1)
                {
                    cost += CostFunction(stationIDs[^2], stationIDs[^1]);
                }
            }
        }

        return new Route(stationIDs, new TimeSpan(0, 0, cost));
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
            output.Append($"{_stations[stationIDs[i]].Name.Replace(" Underground Station", "")}, ");
        }

        return output.ToString();
    }
    
    public virtual void Swap(Route route, int idxA, int idxB)
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
        if (idxA > 0)             updatedCost += CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost += CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost += CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost += CostFunction(stations[idxB], stations[idxB + 1]);
        
        // update the route's length (time taken)
        route.UpdateDuration(updatedTime);
        
        // update the route's cost (unitless value based on number of factors)
        route.UpdateCost(updatedCost);
    }
}