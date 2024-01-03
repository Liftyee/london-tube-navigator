namespace TransportNetwork;

public interface IRoute
{
    public TimeSpan Duration();
    public string GetStart();
    public string GetEnd();
    public List<string> GetPath();
    // public List<DateTime> GetTimes();
    // public DateTime NextOpportunity(DateTime time);
    // public List<Line> LinesUsed();
    // public List<Station> StationsUsed();
    public int Count();
    public void Swap(int a, int b);
    public void UpdateLength(int newLength);
}