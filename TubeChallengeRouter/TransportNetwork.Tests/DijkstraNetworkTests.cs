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
    public void Dijkstra_SetsIntermediate()
    {

        List<string> intermediate;
        int cost = _network.CostFunction("A", "E", out intermediate);
        
        Assert.That(cost, Is.EqualTo(180));
        
        List<string> expectedIntermediate = new();
        expectedIntermediate.Add("B");
        expectedIntermediate.Add("C");
        Assert.That(intermediate, Is.EqualTo(expectedIntermediate));
    }

    [Test]
    public void RandomRoute_HasIntermediate()
    {
        Route result = _network.GenerateRandomRoute();
        
        for (int idx = 0; idx < result.Count-1; idx++)
        {
            List<string> dijResult;
            _network.CostFunction(result.targetStations[idx], result.targetStations[idx + 1], out dijResult);
            Assert.That(result.intermediateStations[idx], Is.EqualTo(dijResult));
        }
    }
}