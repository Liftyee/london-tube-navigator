namespace TransportNetwork;

public class Route : IRoute
{
    private List<string> stationIDs;
    private TimeSpan Length;
    private int pointer;
    
    public Route(List<string> stations, TimeSpan length)
    {
        stationIDs = stations;
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
        if (stationIDs.Count < 20)
        {
            return $"Route with {stationIDs.Count} stations and length {Length.TotalMinutes} minutes: {String.Join(", ", stationIDs)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {stationIDs.Count} stations and length {Length.TotalMinutes} minutes"; 
        }
    }

    public List<string> GetPath()
    {
        return stationIDs;
    }
    
    public int Count()
    {
        return stationIDs.Count;
    }

    public void Swap(int idxA, int idxB)
    {
        string temp = stationIDs[idxA];
        stationIDs[idxA] = stationIDs[idxB];
        stationIDs[idxB] = temp;
    }

    public void UpdateLength(int newLength)
    {
        Length = new TimeSpan(0, newLength, 0);
    }
}