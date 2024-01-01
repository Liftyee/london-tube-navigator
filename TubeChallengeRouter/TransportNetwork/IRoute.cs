namespace TransportNetwork;

public interface IRoute
{
    public TimeSpan Duration();
    public string GetStart();
    public string GetEnd();

    // public List<string> GetPath();
    // public List<DateTime> GetTimes();
    // public DateTime NextOpportunity(DateTime time);
    // public List<Line> LinesUsed();
    // public List<Station> StationsUsed();
    public void SetIndex(int index);
    public string GetCurrentStation();
    public string GetPreviousStation();
    public string GetNextStation();
    public void GoToStart();
    public int NumStations();
}