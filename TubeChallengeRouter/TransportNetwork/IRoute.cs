namespace TransportNetwork;

public interface IRoute
{
    public TimeSpan GetDuration();
    public string GetStart();
    public string GetEnd();

    public List<string> GetPath();
    // public List<DateTime> GetTimes();
    // public DateTime NextOpportunity(DateTime time);
    // public List<Line> LinesUsed();
    // public List<Station> StationsUsed();
}