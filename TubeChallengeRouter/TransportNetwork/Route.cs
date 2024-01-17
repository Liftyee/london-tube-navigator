namespace TransportNetwork;

// TODO: class name temporarily changed
public class Route// : IRoute
{
    public List<string> TargetStations;
    public List<List<string>> IntermediateStations;
    private TimeSpan _duration;
    private int _cost;
    public int Count => TargetStations.Count;
    public int Cost => _cost;
    public TimeSpan Duration => _duration;

    public Route(List<string> stations, TimeSpan duration, int cost, List<List<string>>? intermediateStations = null)
    {
        TargetStations = stations;
        _duration = duration;
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
    }
    
    public override string ToString()
    {
        if (TargetStations.Count < 20)
        {
            return $"Route with {TargetStations.Count} stations and length {_duration.TotalMinutes} minutes: {String.Join(", ", TargetStations)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {TargetStations.Count} stations and length {_duration.TotalMinutes} minutes"; 
        }
    }

    public List<string> GetTargetPath()
    {
        return TargetStations;
    }
    
    internal List<string> GetIntermediateStations(int segmentIndex)
    {
        return IntermediateStations[segmentIndex];
    }
    
    internal List<List<string>> GetIntermediateStations()
    {
        return IntermediateStations;
    }
    
    public void UpdateDuration(TimeSpan newDuration)
    {
        _duration = newDuration;
    }

    public void UpdateCost(int newCost)
    {
        _cost = newCost;
    }

    public void UpdateIntermediateStations(int segmentIndex, List<string> updateTo)
    {
        IntermediateStations[segmentIndex] = updateTo;
    }

    public Route Copy()
    {
        return new Route(this.TargetStations, this.Duration, this.Cost, this.IntermediateStations);
    }
}