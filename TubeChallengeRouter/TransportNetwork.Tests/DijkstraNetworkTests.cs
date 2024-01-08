using System.CodeDom.Compiler;
using DataFetcher;
using TransportNetwork;
using Serilog;
namespace StationTests;

[TestFixture]
public class DijkstraNetworkTests
{
    private Network _network;

    [SetUp]
    public void SetUp()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        _network = new NetworkFactory(new TestNetwork1()).Generate(NetworkType.Dijkstra, stubLogger);
    }

    [Test]
    public void Dijkstra_FindsPath()
    {
        int result = _network.CostFunction("A", "E");
        Assert.That(result, Is.EqualTo(180)); // cost is in seconds
    }

    [Test]
    public void RandomRoute_HasIntermediate()
    {
        Route result = _network.GenerateRandomRoute();
        
    }
}