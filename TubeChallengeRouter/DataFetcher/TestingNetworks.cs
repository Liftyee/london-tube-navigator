using System.Diagnostics;
using System.Diagnostics.Metrics;
using Serilog.Core;
using System.Diagnostics;
using Serilog.Debugging;
using TransportNetwork;


namespace DataFetcher;

public class LinearNetwork : INetworkDataFetcher
{
    private int _numNodes;
    public LinearNetwork(int nNodes)
    {
        _numNodes = nNodes;
    }
    public void PopulateNetworkStructure(ref Network network)
    {
        for (int i = 0; i < _numNodes; i++)
        {
            network.AddStationId(i.ToString());
        }

        for (int i = 0; i < _numNodes - 1; i++)
        {
            network.LinkStationsPartial(i.ToString(), (i + 1).ToString(), Dir.Inbound);
            network.LinkStationsPartial((i+1).ToString(), i.ToString(), Dir.Outbound);
        }
    }

    public void SetProgressCallback(Action<double> callback)
    {
        throw new NotSupportedException();
    }
}

public class TestNetwork1 : INetworkDataFetcher
{
    public void PopulateNetworkStructure(ref Network network)
    {
        network.AddStationId("A");
        network.AddStationId("B");
        network.AddStationId("C");
        network.AddStationId("D");
        network.AddStationId("E");
        network.LinkStationsPartial("A", "B", Dir.Bidirectional, null);
        network.LinkStationsPartial("B", "C", Dir.Bidirectional, null);
        network.LinkStationsPartial("B", "D", Dir.Bidirectional, null);
        network.LinkStationsPartial("C", "E", Dir.Bidirectional, null);
        network.LinkStationsPartial("D", "E", Dir.Bidirectional, null);
    }

    public void SetProgressCallback(Action<double> callback)
    {
        throw new NotSupportedException();
    }
}

public class InvalidBranchIdException : Exception
{
    public InvalidBranchIdException(string message) : base(message)
    {
    }
}