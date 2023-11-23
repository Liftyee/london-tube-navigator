namespace TransportNetwork;
using IO.Swagger.Model;

public interface IRoute
{
    public TimeSpan GetDuration();
    public Station GetStart();
    public Station GetEnd();
    public List<DateTime> GetTimes();
    public DateTime NextOpportunity(DateTime time);
    public ! LinesUsed();
    public ! StationsUsed();
}

public class Interchange
{
    
}

public class TrainRoute(IRoute)
{
    
}

public class WalkingRoute(IRoute)
{
    
}

public class Station
{
    public readonly string Name;
    protected Timetable? _timetable;

    public Station(string name)
    {
        this.Name = name;
    }

    public Station(StationData config)
    {
        this.Name = ;
        this._timetable = 
    }
}

public struct StationDataconfig
{
    public string Name;
    public int ID;
    public string Naptan;
    public Timetable Timetable;
}

public class TransportNetwork
{
    protected List<Station> stations;
    
}

public class Timetable
{
    // encode train time data.
    // we need to store this data on a per-line basis. 
}

