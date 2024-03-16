namespace TransportNetwork;

// Enum to clearly represent the direction of a link
public enum Dir
{
    Inbound,
    Outbound,
    Bidirectional
}

public class Line
{
    public readonly string Name;
    public readonly string Id;
    public Line(string id, string name)
    {
        Name = name;
        Id = id; 
    }
}

public struct Link
{
    public readonly Station Destination;
    internal TimeSpan Duration { get; private set; }
    internal Line? Line { get; private set; }
    internal Dir Dir { get; private set; }
    
    public Link(Station end, Line? line, Dir dir)
    {
        Destination = end;
        Line = line;
        Dir = dir;
        Duration = new TimeSpan(0, 1, 0);
    }

    internal void SetDuration(TimeSpan duration)
    {
        Duration = duration;
    }

    internal void SetLine(Line line)
    {
        if (Line != null)
        {
            throw new InvalidOperationException("Cannot change the line of a link");
        }

        Line = line;
    }

    public int GetCost() // cost is duration in seconds (for now...)
    {
        return (int)Duration.TotalSeconds;
    }
}