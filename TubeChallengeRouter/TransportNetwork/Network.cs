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
            return (int)_stations[startId].GetLinkById(endId).Duration.Value.TotalMinutes;
        }
        else
        {
            throw new ArgumentException("Simple network doesn't support cost function for non-linked stations (use overrides)");
        }
    }

    // generate random route through all stations
    public virtual IRoute GenerateRandomRoute()
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

        return new Route(stationIDs, cost);
    }

    // TODO: Put the indexing behaviour outside of the Route class?
    public virtual int CostFunction(IRoute route)
    {
        int cost = 0;
        for (int i = 0; i < route.Count() - 1; i++)
        {
            route.SetIndex(i);
            cost += CostFunction(route.GetCurrentStation(), route.GetNextStation());
        }

        return cost;
    }

    // convert route naptan IDs into a string for readability
    public string RouteToStringStationSeq(IRoute route)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < route.Count(); i++)
        {
            route.SetIndex(i);
            output.Append($"{_stations[route.GetCurrentStation()].Name.Replace(" Underground Station", "")}, ");
        }

        return output.ToString();
    }
}