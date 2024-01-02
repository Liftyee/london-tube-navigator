namespace TransportNetwork;

public enum Dir
{
    Inbound,
    Outbound
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

public class Link
{
    private ITimetable? TrainTimes;
    public readonly Station Destination;
    public readonly Station Origin;
    internal TimeSpan? Duration { get; private set; }
    internal Line? Line { get; private set; }
    public bool FullyPopulated;
    public Dir Dir;

    public Link(Station start, Station end, TimeSpan duration)
    {
        throw new NotImplementedException("This constructor not supported!");
        this.Destination = end;
        this.Origin = start;
        this.Duration = duration;
        this.FullyPopulated = false;
    }
    
    public Link(Station start, Station end, Line? line, Dir dir)
    {
        this.Destination = end;
        this.Origin = start;
        this.FullyPopulated = false;
        this.Line = line;
        this.Dir = dir;
        this.Duration = new TimeSpan(0, 1, 0);
    }

    internal void SetDuration(TimeSpan duration)
    {
        if (this.FullyPopulated)
        {
            throw new Exception("Tried to edit an already fully populated link!");
        }

        this.Duration = duration;
        if (this.Line is not null)
        {
            this.FullyPopulated = true;
        }
#warning "Timetable check not used yet for FullyPopulated!"
    }

    public override bool Equals(Object other)
    {
        if ((other == null) || !this.GetType().Equals(other.GetType()))
        {
            return false; // link is never equal to something that isn't a link
        }
        else
        {
            Link otherLink = (Link)other;
            if (this.Destination.NaptanId == otherLink.Destination.NaptanId &&
                this.Origin.NaptanId == otherLink.Origin.NaptanId &&
                this.Line?.Id == otherLink.Line?.Id &&
                this.Dir == otherLink.Dir &&
                this.Duration == otherLink.Duration)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}