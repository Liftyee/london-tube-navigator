namespace TransportNetwork;

public class Route : IRoute
{
    internal List<string> targetStations;
    internal List<List<string>> intermediateStations;
    private TimeSpan Length;
    
    public Route(List<string> stations, TimeSpan length)
    {
        targetStations = stations;
        Length = length;
    }

    public Route(List<string> stations, int minutes) : this(stations, new TimeSpan(0, minutes, 0))
    { }

    public TimeSpan Duration()
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
        if (targetStations.Count < 20)
        {
            return $"Route with {targetStations.Count} stations and length {Length.TotalMinutes} minutes: {String.Join(", ", targetStations)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {targetStations.Count} stations and length {Length.TotalMinutes} minutes"; 
        }
    }

    public List<string> GetPath()
    {
        return targetStations;
    }
    
    internal List<string> GetIntermediateStations(int segmentIndex)
    {
        return intermediateStations[segmentIndex];
    }
    
    public int Count()
    {
        return targetStations.Count;
    }
    
    public void UpdateLength(int newLength)
    {
        Length = new TimeSpan(0, newLength, 0);
    }
}