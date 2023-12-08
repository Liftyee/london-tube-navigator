using System.Text;
using NUnit.Framework.Constraints;

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
    public readonly string? Name;
    public readonly List<Line>? lines;
    private List<Link>? links;
    public readonly string NaptanID;

    public Station(StationData config)
    {
        throw new NotImplementedException();
    }

    public Station(TflApiPresentationEntitiesStopPoint tfldata)
    {
        this.Name = tfldata.CommonName;

        foreach (object line in tfldata.Lines) // THIS IS BAD FIX THIS
        {
            throw new NotImplementedException();
        }
    }

    public Station(string naptan) : this()
    {
        this.NaptanID = naptan;
    }

    private Station()
    {
        links = new List<Link>();
    }

    public void AddLink(Link newLink)
    {
        this.links.Add(newLink);
    } 
    
    public List<Link> GetLinks()
    {
        return this.links;
    }
}

[Serializable]
public class Link
{
    private ITimetable? TrainTimes;
    public readonly Station Destination;
    public readonly Station Origin;
    public readonly TimeSpan? Duration;

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
        _stations.Add(stationToAdd.NaptanID, stationToAdd);
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
                output.Append($"{link.Destination.Name}, ");
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
}

public class CachedDataFetcher : INetworkDataFetcher
{
    public List<Station> GetStations()
    {
        throw new NotImplementedException();
    }

    public List<Line> GetLines()
    {
        throw new NotImplementedException();
    }
}