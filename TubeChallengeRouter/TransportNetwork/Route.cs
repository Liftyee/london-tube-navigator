namespace TransportNetwork;

// HACK: class name temporarily changed
public class Route// : IRoute
{
    internal List<string> targetStations;
    internal List<List<string>> intermediateStations;
    private TimeSpan _duration;
    private int _cost;
    public int Count => targetStations.Count;
    public int Cost => _cost;
    public TimeSpan Duration => _duration;
    
    public Route(List<string> stations, TimeSpan duration)
    {
        targetStations = stations;
        _duration = duration;
    }
    
    public override string ToString()
    {
        if (targetStations.Count < 20)
        {
            return $"Route with {targetStations.Count} stations and length {_duration.TotalMinutes} minutes: {String.Join(", ", targetStations)}";
        }
        else // don't return all the stations if there are too many
        {
            return $"Route with {targetStations.Count} stations and length {_duration.TotalMinutes} minutes"; 
        }
    }

    public List<string> GetTargetPath()
    {
        return targetStations;
    }
    
    internal List<string> GetIntermediateStations(int segmentIndex)
    {
        return intermediateStations[segmentIndex];
    }
    
    public void UpdateDuration(TimeSpan newDuration)
    {
        _duration = newDuration;
    }

    public void UpdateCost(int newCost)
    {
        _cost = newCost;
    }
}