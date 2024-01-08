namespace TransportNetwork;

// HACK: class name temporarily changed
public class Route// : IRoute
{
    public List<string> targetStations;
    internal List<List<string>> intermediateStations;
    private TimeSpan _duration;
    private int _cost;
    public int Count => targetStations.Count;
    public int Cost => _cost;
    public TimeSpan Duration => _duration;

    public Route(List<string> stations, TimeSpan duration, int cost, List<List<string>>? intermediateStations = null)
    {
        targetStations = stations;
        _duration = duration;
        _cost = cost;
        
        if (intermediateStations is null)
        {
            this.intermediateStations = new List<List<string>>();
        }
        else
        {
            this.intermediateStations = intermediateStations;
        }
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
    
    internal List<List<string>> GetIntermediateStations()
    {
        return intermediateStations;
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
        intermediateStations[segmentIndex] = updateTo;
    } 
}