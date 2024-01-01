namespace TransportNetwork;

public class Route : IRoute
{
    private List<string> stationIDs;
    private TimeSpan Length;
    
    public Route(List<string> stations, TimeSpan length)
    {
        stationIDs = stations;
        Length = length;
    }

    public Route(List<string> stations, int minutes) : this(stations, new TimeSpan(0, minutes, 0))
    { }

    public TimeSpan GetDuration()
    {
        return Length;
    }

    public string GetStart()
    {
        throw new NotImplementedException();
    }

    public string GetEnd()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Route with {stationIDs.Count} stations and length {Length}";
    }

    public List<string> GetPath()
    {
        return stationIDs;
    }
}