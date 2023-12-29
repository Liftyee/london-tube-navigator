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
public interface IRoute
{
    public TimeSpan GetDuration();
    public Station GetStart();
    public Station GetEnd();
    public List<DateTime> GetTimes();
    public DateTime NextOpportunity(DateTime time);
    public List<Line> LinesUsed();
    public List<Station> StationsUsed();
}

public class Interchange
{
    
}

public class TrainRoute : IRoute
{
    public TrainRoute()
    {
        throw new NotImplementedException();
    }

    public TimeSpan GetDuration()
    {
        throw new NotImplementedException();
    }

    public Station GetStart()
    {
        throw new NotImplementedException();
    }

    public Station GetEnd()
    {
        throw new NotImplementedException();
    }

    public List<DateTime> GetTimes()
    {
        throw new NotImplementedException();
    }

    public DateTime NextOpportunity(DateTime time)
    {
        throw new NotImplementedException();
    }

    public List<Line> LinesUsed()
    {
        throw new NotImplementedException();
    }

    public List<Station> StationsUsed()
    {
        throw new NotImplementedException();
    }
}

public class WalkingRoute : IRoute
{
    public WalkingRoute()
    {
        throw new NotImplementedException();
    }

    public TimeSpan GetDuration()
    {
        throw new NotImplementedException();
    }

    public Station GetStart()
    {
        throw new NotImplementedException();
    }

    public Station GetEnd()
    {
        throw new NotImplementedException();
    }

    public List<DateTime> GetTimes()
    {
        throw new NotImplementedException();
    }

    public DateTime NextOpportunity(DateTime time)
    {
        throw new NotImplementedException();
    }

    public List<Line> LinesUsed()
    {
        throw new NotImplementedException();
    }

    public List<Station> StationsUsed()
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class Station
{
    // some attributes internal so that data fetchers can update values after instantiation
    internal string? Name;
    internal List<Line>? Lines;
    private Dictionary<string, Link> _links;
    public readonly string NaptanId;

    public Station(string naptan)
    {
        NaptanId = naptan;
        _links = new Dictionary<string, Link>();
    }
    
    public Station(string naptan, string name) : this(naptan)
    {
        Name = name;
    }

    public void AddLink(Link newLink)
    {
        // TODO: combine line and station information for key to prevent error
        _links.Add(newLink.Destination.NaptanId, newLink);
    } 
    
    public List<Link> GetLinks()
    {
        return this._links.Values.ToList();
    }

    // TODO: this might get slow if there are lots of links, consider using a dictionary for O(1)
    public bool HasLink(string destID)
    {
        return _links.ContainsKey(destID);
    }

    public Link GetLinkById(string Id)
    {
        return _links[Id];
    }
}

public enum Dir
{
    Inbound,
    Outbound
}

[Serializable]
public class Link
{
    private ITimetable? TrainTimes;
    public readonly Station Destination;
    public readonly Station Origin;
    internal TimeSpan? Duration { get; private set; }
    internal Line? Line { get; private set; }
    public bool FullyPopulated;
    public Dir Dir;

    public Link(Station start, Station end, TimeSpan duration)
    {
        throw new NotImplementedException("This constructor not supported!");
        this.Destination = end;
        this.Origin = start;
        this.Duration = duration;
        this.FullyPopulated = false;
    }
    
    public Link(Station start, Station end, Line? line, Dir dir)
    {
        this.Destination = end;
        this.Origin = start;
        this.FullyPopulated = false;
        this.Line = line;
        this.Dir = dir;
    }

    internal void SetDuration(TimeSpan duration)
    {
        if (this.FullyPopulated)
        {
            throw new Exception("Tried to edit an already fully populated link!");
        }

        this.Duration = duration;
        if (this.Line is not null)
        {
            this.FullyPopulated = true;
        }
        #warning "Timetable check not used yet for FullyPopulated!"
    }
}

[Serializable]
public class Line
{
    public readonly string Name;
    public readonly string Id;
    public Line(string id, string name)
    {
        Name = name;
        Id = id; 
    }
}

public struct StationData
{
    public string Name;
    public int ID;
    public string Naptan;
    public ITimetable Timetable;
}

public enum NetworkType
{
    Simple,
    Floyd,
    Dijkstra
}

[Serializable]
public class Network
{
    protected Dictionary<string, Station> _stations;
    protected Dictionary<int, Line> _lines;
    protected ILogger logger;
    protected const int INF_COST = Int32.MaxValue;
    
    public Network()
    {
        //logger = loggerFactory.CreateLogger<Network>();
        _stations = new Dictionary<string, Station>();
        _lines = new Dictionary<int, Line>();
    }

    public virtual void Initialise()
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
    
    // TODO: Modify to use Inbound/Outbound
    public void LinkStations(Station startStation, Station endStation, TimeSpan timeBetween, bool directed=false)
    {
        startStation.AddLink(new Link(startStation, endStation, timeBetween));
        if (!directed)
        {
            endStation.AddLink(new Link(endStation, startStation, timeBetween));
        }
    }

    public void LinkStations(string startId, string endId, TimeSpan timeBetween, bool directed = false)
    {
        Station startObject = _stations[startId];
        Station endObject = _stations[endId];
        LinkStations(startObject, endObject, timeBetween, directed);
    }
    
    public void LinkStationsPartial(string startId, string endId, Dir direction, Line? line=null)
    {
        Station startObject = _stations[startId];
        Station endObject = _stations[endId];
        LinkStationsPartial(startObject, endObject, direction, line);
    }
    
    public void LinkStationsPartial(Station startStation, Station endStation, Dir direction, Line? line)
    {
        startStation.AddLink(new Link(startStation, endStation, line, direction));
    }

    public bool HasStationByID(string ID)
    {
        return _stations.Keys.Contains(ID);
    }
    
    public override string ToString()
    {
        return $"Network with {_stations.Count} stations and {_lines.Count} lines";
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
            return INF_COST;
        }
    }
}

public class FloydCostNetwork : Network
{
    private Dictionary<string, Dictionary<string, int>> _costMatrix; // format: [start station][end station]
    public override void Initialise()
    {
        PreprocessFloyd();
    }
    public override int CostFunction(string startId, string endId)
    {
        return _costMatrix[startId][endId];
    }
    
    private void PreprocessFloyd()
    {
        logger.Information("Preprocessing Floyd-Warshall weights...");
        // initialise cost matrix
        _costMatrix = new Dictionary<string, Dictionary<string, int>>();
        foreach (string stationID in _stations.Keys)
        {
            _costMatrix[stationID] = new Dictionary<string, int>();
            foreach (string station2ID in _stations.Keys)
            {
                if (stationID != station2ID)
                {
                    _costMatrix[stationID][station2ID] = INF_COST;
                }
                else
                {
                    _costMatrix[stationID][station2ID] = 0; // no cost to itself
                }
            }
        }
        logger.Debug("Cost matrix initialised");
        
        // populate cost matrix with links for each station
        foreach (Station station in _stations.Values)
        {
            foreach (Link link in station.GetLinks())
            {
                _costMatrix[station.NaptanId][link.Destination.NaptanId] = (int)link.Duration.Value.TotalMinutes;
            }
        }
        logger.Debug("Links populated");
        
        Stopwatch timer = new Stopwatch();
        timer.Start();
        // run Floyd-Warshall
        foreach (string k in _stations.Keys)
        {
            foreach (string i in _stations.Keys)
            {
                foreach (string j in _stations.Keys)
                {
                    if (_costMatrix[i][j] > _costMatrix[i][k] + _costMatrix[k][j])
                    {
                        _costMatrix[i][j] = _costMatrix[i][k] + _costMatrix[k][j];
                    }
                }
            }
            logger.Debug("Mid-station {A} processed in {B}ms", k, timer.ElapsedMilliseconds);
        }
        logger.Information("Done! Took {A}ms", timer.ElapsedMilliseconds);
    }
}

public class NetworkFactory
{
    private INetworkDataFetcher _dataSource;
    public NetworkFactory(INetworkDataFetcher dataSource)
    {
        _dataSource = dataSource;
    }

    public Network Generate(NetworkType type)
    {
        Network result;
        switch (type)
        {
            case NetworkType.Simple:
                result = new Network();
                break;
            case NetworkType.Floyd:
                result = new FloydCostNetwork();
                break;
            case NetworkType.Dijkstra:
                throw new NotImplementedException();
            default:
                throw new NotImplementedException();
        }
        
        _dataSource.PopulateNetworkStructure(ref result);
        return result;
    }
}


public interface INetworkDataFetcher
{
    //public List<Station> GetStations();
    //public List<Line> GetLinks();

    //public void UpdateStationData(ref Station station);
    //public void UpdateLineData(ref Line line);

    public void PopulateNetworkStructure(ref Network network);
} 

public interface ITimetable
{
    
}