using System.Diagnostics;
using System.Diagnostics.Metrics;
using Serilog.Core;
using System.Diagnostics;
using Serilog.Debugging;
using TransportNetwork;


namespace DataFetcher;

public class LinearNetwork : INetworkDataFetcher
{
    private int numNodes;
    public LinearNetwork(int nNodes)
    {
        numNodes = nNodes;
    }
    public void PopulateNetworkStructure(ref Network network)
    {
        for (int i = 0; i < numNodes; i++)
        {
            network.AddStationByIdIfNotPresent(i.ToString());
        }

        for (int i = 0; i < numNodes - 1; i++)
        {
            network.LinkStationsPartial(i.ToString(), (i + 1).ToString(), Dir.Inbound);
            network.LinkStationsPartial((i+1).ToString(), i.ToString(), Dir.Outbound);
        }
    }
}

public class TestNetwork1 : INetworkDataFetcher
{
    public void PopulateNetworkStructure(ref Network _network)
    {
        _network.AddStation(new Station("A"));
        _network.AddStation(new Station("B"));
        _network.AddStation(new Station("C"));
        _network.AddStation(new Station("D"));
        _network.AddStation(new Station("E"));
        _network.LinkStationsPartial("A", "B", Dir.Inbound, null);
        _network.LinkStationsPartial("B", "C", Dir.Inbound, null);
        _network.LinkStationsPartial("B", "D", Dir.Inbound, null);
        _network.LinkStationsPartial("C", "E", Dir.Inbound, null);
        _network.LinkStationsPartial("D", "E", Dir.Inbound, null);
    }
}

public class InvalidBranchIDException : Exception
{
    public InvalidBranchIDException(string message) : base(message)
    {
    }
}