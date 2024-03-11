namespace TransportNetwork;

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
    private ITimetable? _trainTimes;
    public readonly Station Destination;
    public readonly Station Origin;
    internal TimeSpan Duration { get; private set; }
    public Line? Line { get; private set; }
    public Dir Dir { get; private set; }
    private bool _durationEdited;
    
    public Link(Station start, Station end, Line? line, Dir dir)
    {
        Destination = end;
        Origin = start;
        Line = line;
        Dir = dir;
        Duration = new TimeSpan(0, 1, 0);
        _durationEdited = false;
    }

    internal void SetDuration(TimeSpan duration)
    {
        if (_durationEdited)
        {
            throw new InvalidOperationException("Cannot change the duration of a link");
        }

        Duration = duration;
        _durationEdited = true;
    }

    internal void SetLine(Line line)
    {
        if (Line != null)
        {
            throw new InvalidOperationException("Cannot change the line of a link");
        }

        Line = line;
    }

    public override bool Equals(Object other)
    {
        if ((other == null) || !GetType().Equals(other.GetType()))
        {
            return false; // link is never equal to something that isn't a link
        }

        Link otherLink = (Link)other;
        if (Destination.NaptanId == otherLink.Destination.NaptanId &&
            Origin.NaptanId == otherLink.Origin.NaptanId &&
            Line?.Id == otherLink.Line?.Id &&
            Dir == otherLink.Dir &&
            Duration == otherLink.Duration)
        {
            return true;
        }

        return false;
    }

    public int GetCost() // cost is duration in seconds (for now...)
    {
        return (int)Duration.TotalSeconds;
    }
}