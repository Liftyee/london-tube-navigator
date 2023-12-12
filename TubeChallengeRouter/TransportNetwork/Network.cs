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
    internal TimeSpan? Duration { get; private set; }
    private Line? Line;
    public bool FullyPopulated;

    public Link(Station start, Station end, TimeSpan duration)
    {
        this.Destination = end;
        this.Origin = start;
        this.Duration = duration;
        this.FullyPopulated = false;
    }
    
    public Link(Station start, Station end)
    {
        this.Destination = end;
        this.Origin = start;
        this.FullyPopulated = false;
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

    public void LinkStations(string startId, string endId, TimeSpan timeBetween, bool directed = false)
    {
        Station startObject = _stations[startId];
        Station endObject = _stations[endId];
        LinkStations(startObject, endObject, timeBetween, directed);
    }
    
    
    public void TentativeLinkStations(string startId, string endId, bool directed = false)
    {
        Station startObject = _stations[startId];
        Station endObject = _stations[endId];
        TentativeLinkStations(startObject, endObject, directed);
    }
    
    public void TentativeLinkStations(Station startStation, Station endStation, bool directed=false)
    {
        startStation.AddLink(new Link(startStation, endStation));
        if (!directed)
        {
            endStation.AddLink(new Link(endStation, startStation));
        }
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

    public void UpdateStationData(ref Station station);
    public void UpdateLineData(ref Line line);

    public void PopulateNetworkStructure(ref Network network);
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

    public void UpdateStationData(ref Station station)
    {
        TflApiPresentationEntitiesStopPoint result = stationCache[station.NaptanId];
        
        station.Name = result.CommonName;

        #warning "Adding line information not supported yet!
    }

    public void UpdateLineData(ref Line line)
    {
        throw new NotImplementedException();
    }

    public void PopulateNetworkStructure(ref Network network)
    {
        #warning "Use https://api.tfl.gov.uk/Line/Piccadilly/Route/Sequence/inbound RouteSequence API to do this!"
        
        string[] lines = new [] {"bakerloo", "central", "circle", "district", "hammersmith-city", "jubilee", "metropolitan", "northern", "piccadilly", "victoria", "waterloo-city"};
        foreach (string lineName in lines)
        {
            TflApiPresentationEntitiesRouteSequence result = lineApi.LineRouteSequence(lineName, "inbound");
            List<TflApiPresentationEntitiesOrderedRoute> orderedRoutes = result.OrderedLineRoutes;
            foreach (TflApiPresentationEntitiesOrderedRoute route in orderedRoutes)
            {
                List<string> stationIds = route.NaptanIds;
                for (int i = 0; i < stationIds.Count - 1; i++)
                {
                    string start = stationIds[i];
                    string end = stationIds[i + 1];
                    network.TentativeLinkStations(start, end);
                }
            }
        }
    }
}