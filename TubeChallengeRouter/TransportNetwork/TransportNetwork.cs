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
    
    public Station(string name)
    {
        this.Name = name;
    }

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
    protected List<Station> stations;
    protected List<Line> lines;
}

public class Timetable
{
    // encode train time data.
    // we need to store this data on a per-line basis. 
}

