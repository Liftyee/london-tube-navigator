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

public class Station
{
    public readonly string Name;
    protected Timetable? Timetable;
    public readonly List<Line> lines;
    private OutboundLink links;
    public readonly string? NaptanID;

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
}

public class OutboundLink
{
    
}

public class Line
{
    
}

public struct StationData
{
    public string Name;
    public int ID;
    public string Naptan;
    public Timetable Timetable;
}

public class TransportNetwork
{
    private Dictionary<int, List<Station>> stations;
    private Dictionary<int, List<Line>> lines;

    public TransportNetwork(INetworkDataFetcher fetcher)
    {
        List<Station> tempStations = fetcher.GetStations();
        List<Line> tempLines = fetcher.GetLines();
    }
}

public class Timetable
{
    // encode train time data.
    // we need to store this data on a per-line basis. 
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