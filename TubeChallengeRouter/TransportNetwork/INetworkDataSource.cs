namespace TransportNetwork;

public interface INetworkDataSource
{
    public void PopulateNetworkStructure(ref Network network);
    public void SetProgressCallback(Action<double> callback);
} 
