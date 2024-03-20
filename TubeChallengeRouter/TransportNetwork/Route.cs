namespace TransportNetwork;

public struct Route
{
    public List<string> TargetStations;
    public List<List<string>> InterStations;
    public int Count => TargetStations.Count;
    public int Cost { get; private set; }

    // NOTE: This is only true as long as cost = journey time in seconds
    public int Duration => Cost / 60;

    public Route(List<string> stations, int cost, List<List<string>>? intermediateStations = null)
    {
        TargetStations = stations;
        Cost = cost;
        
        if (intermediateStations is null)
        {
            this.InterStations = new List<List<string>>();
        }
        else
        {
            this.InterStations = intermediateStations;
        }
    }

    public Route(List<string> stations)
    {
        TargetStations = stations;
        InterStations = new List<List<string>>();
    }
    
    public override string ToString()
    {
        if (TargetStations.Count < 20)
        {
            return $"Route with {TargetStations.Count} stations and length {Duration} minutes: {String.Join(", ", TargetStations)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {TargetStations.Count} stations and length {Duration} minutes (cost {Cost})"; 
        }
    }
    
    public void UpdateCost(int newCost)
    {
        Cost = newCost;
    }
    
    private int InterStationCount()
    {
        int count = 0;
        foreach (var segment in InterStations)
        {
            count += segment.Count;
        }

        return count;
    }

    public int InterCount => InterStationCount();
}