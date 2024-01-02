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
            return $"Route with {stationIDs.Count} stations and length {Length}: {String.Join(", ", stationIDs)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {stationIDs.Count} stations and length {Length}"; 
        }
    }

    private List<string> GetPath()
    {
        return stationIDs;
    }
    
    public void SetIndex(int index)
    {
        if (index < 0 || index >= stationIDs.Count)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }
        pointer = index;
    }
    
    public string GetCurrentStation()
    {
        return stationIDs[pointer];
    }
    
    public string GetPreviousStation()
    {
        if (pointer == 0)
        {
            throw new ArgumentOutOfRangeException("No previous station; pointer at zero");
        }
        return stationIDs[pointer-1];
    }
    
    public string GetNextStation()
    {
        if (pointer == stationIDs.Count - 1)
        {
            throw new ArgumentOutOfRangeException("No next station; pointer at end");
        }
        return stationIDs[pointer+1];
    }
    
    public void GoToStart()
    {
        pointer = 0;
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