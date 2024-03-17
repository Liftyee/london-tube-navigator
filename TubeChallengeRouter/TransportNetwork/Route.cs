namespace TransportNetwork;

public struct Route
{
    public List<string> TargetStations;
    public List<List<string>> IntermediateStations;
    private int _cost;
    public int Count => TargetStations.Count;
    public int Cost => _cost;
    
    // NOTE: This is only true as long as cost = journey time in seconds
    public int Duration => _cost / 60;

    public Route(List<string> stations, int cost, List<List<string>>? intermediateStations = null)
    {
        TargetStations = stations;
        _cost = cost;
        
        if (intermediateStations is null)
        {
            this.IntermediateStations = new List<List<string>>();
        }
        else
        {
            this.IntermediateStations = intermediateStations;
        }
    }

    public Route(List<string> stations)
    {
        TargetStations = stations;
        IntermediateStations = new List<List<string>>();
    }
    
    public override string ToString()
    {
        if (TargetStations.Count < 20)
        {
            return $"Route with {TargetStations.Count} stations and length {Duration} minutes: {String.Join(", ", TargetStations)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {TargetStations.Count} stations and length {Duration} minutes (cost {_cost})"; 
        }
    }

    public List<string> GetTargetPath()
    {
        return TargetStations;
    }
    
    public void UpdateCost(int newCost)
    {
        _cost = newCost;
    }
    
    private int InterStationCount()
    {
        int count = 0;
        foreach (var segment in IntermediateStations)
        {
            count += segment.Count;
        }

        return count;
    }

    public int InterCount => InterStationCount();
}