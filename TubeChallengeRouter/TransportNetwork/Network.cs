using System.Text;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace TransportNetwork;
using IO.Swagger.Model;

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
    private List<Link> _links;
    public readonly string NaptanId;

    public Station(string naptan)
    {
        NaptanId = naptan;
        _links = new List<Link>();
    }

    public void AddLink(Link newLink)
    {
        _links.Add(newLink);
    } 
    
    public List<Link> GetLinks()
    {
        return this._links;
    }
}

[Serializable]
public class Link
{
    private ITimetable? TrainTimes;
    public readonly Station Destination;
    public readonly Station Origin;
    public readonly TimeSpan? Duration;
    internal Line? Line;

    public Link(Station start, Station end, TimeSpan duration)
    {
        this.Destination = end;
        this.Origin = start;
        this.Duration = duration;
    }
}

[Serializable]
public class Line
{
    
}

public struct StationData
{
    public string Name;
    public int ID;
    public string Naptan;
    public ITimetable Timetable;
}

[Serializable]
public class Network
{
    private Dictionary<string, Station> _stations;
    private Dictionary<int, Line> _lines;

    public Network(INetworkDataFetcher fetcher) : this()
    {
        List<Station> tempStations = fetcher.GetStations();
        List<Line> tempLines = fetcher.GetLines();
    }

    public Network()
    {
        _stations = new Dictionary<string, Station>();
        _lines = new Dictionary<int, Line>();
    }

    public void AddStation(Station stationToAdd)
    {
        _stations.Add(stationToAdd.NaptanId, stationToAdd);
    }

    public void LinkStations(Station startStation, Station endStation, TimeSpan timeBetween, bool directed=false)
    {
        startStation.AddLink(new Link(startStation, endStation, timeBetween));
        if (!directed)
        {
            endStation.AddLink(new Link(endStation, startStation, timeBetween));
        }
    }

    public void LinkStations(string startID, string endID, TimeSpan timeBetween, bool directed = false)
    {
        Station startObject = _stations[startID];
        Station endObject = _stations[endID];
        LinkStations(startObject, endObject, timeBetween, directed);
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
                output.Append($"{link.Destination.NaptanId} ({link.Duration.ToString()}), ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }
}

public interface ITimetable
{
    
}

public interface INetworkDataFetcher
{
    public List<Station> GetStations();
    public List<Line> GetLines();

    public bool UpdateStationData(ref Station station);
    public bool UpdateLineData(ref Line line);

    public bool PopulateNetworkStructure(ref Network network);
}

public class TfLModelWrapper : INetworkDataFetcher
{
    private StopPointApi stationFetcher;
    private LineApi lineApi;
    private Dictionary<string, TflApiPresentationEntitiesStopPoint> stationCache;
    private List<TflApiPresentationEntitiesLine> lineCache;
    public TfLModelWrapper()
    {
        var apiconfig = new Configuration
        {
            BasePath = "https://api.tfl.gov.uk"
        };
        lineApi = new LineApi(apiconfig);
        stationFetcher = new StopPointApi(apiconfig);
        stationCache = new Dictionary<string, TflApiPresentationEntitiesStopPoint>();
        lineCache = new List<TflApiPresentationEntitiesLine>();
    }

    public List<Station> GetStations()
    {
        throw new NotImplementedException();
    }

    public List<Line> GetLines()
    {
        throw new NotImplementedException();
    }

    public bool UpdateCaches(List<string> lineNames)
    {
        lineCache = lineApi.LineGet(lineNames);
        foreach (TflApiPresentationEntitiesLine line in lineCache)
        {
            List<TflApiPresentationEntitiesStopPoint> linestations = lineApi.LineStopPoints(line.Id);
            foreach (TflApiPresentationEntitiesStopPoint station in linestations)
            {
                stationCache[station.NaptanId] = station;
            }
        }
        return true;
    }

    public bool UpdateStationData(ref Station station)
    {
        TflApiPresentationEntitiesStopPoint result = stationCache[station.NaptanId];
        
        station.Name = result.CommonName;

        #warning "Adding line information not supported yet!
        
        return true;
    }

    public bool UpdateLineData(ref Line line)
    {
        throw new NotImplementedException();
    }

    public bool PopulateNetworkStructure(ref Network network)
    {
        throw new NotImplementedException();
    }
}