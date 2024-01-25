namespace TransportNetwork;

public interface INetworkDataFetcher
{
    //public List<Station> GetStations();
    //public List<Line> GetLinks();

    //public void UpdateStationData(ref Station station);
    //public void UpdateLineData(ref Line line);

    public void PopulateNetworkStructure(ref Network network);
    public void SetProgressCallback(Action<double> callback);
} 
