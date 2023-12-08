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

    public Station(string naptan)
    {
        this.NaptanID = naptan;
    }

    public void AddLink(Link newLink)
    {
        this.links.Add(newLink);
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

    public Network(INetworkDataFetcher fetcher)
    {
        List<Station> tempStations = fetcher.GetStations();
        List<Line> tempLines = fetcher.GetLines();
    }

    public Network()
    {
        
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

    public bool HasStationByID(string ID)
    {
        return _stations.Keys.Contains(ID);
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