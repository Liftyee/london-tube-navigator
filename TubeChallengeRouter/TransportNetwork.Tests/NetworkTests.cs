using DataFetcher;
using Serilog;
using TransportNetwork;

namespace StationTests;

public class NetworkTests
{
    private Network _network;

    [SetUp]
    public void SetUp()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        _network = new NetworkFactory(new TestNetwork1()).Generate(NetworkType.Dijkstra, stubLogger);
    }

    [Test]
    public void SwapInsert_InsertsStation()
    {
        // generate a random route
        Route route = _network.GenerateRandomRoute();
        
        // keep track of what they were so we can compare
        string old2 = route.TargetStations[2];
        string old4 = route.TargetStations[4];
        
        _network.TakeAndInsert(route, 2, 4);
        
        // because we are taking from before our target position (and everything gets shifted by 1),
        // the final index should be one less than 4
        Assert.That(route.TargetStations[2], Is.Not.EqualTo(old2));
        Assert.That(route.TargetStations[4-1], Is.EqualTo(old2));
        
        // try swapping in the other direction
        route = _network.GenerateRandomRoute();
        
        // keep track of what they were so we can compare
        string old1 = route.TargetStations[1];
        string old3 = route.TargetStations[3];
        
        _network.TakeAndInsert(route, 3, 1);
        
        // because we are taking from after our target position, the final index should be 1
        Assert.That(route.TargetStations[3], Is.Not.EqualTo(old3));
        Assert.That(route.TargetStations[1], Is.EqualTo(old3));
    }

    [Test]
    public void SwapInsert_UpdatesCost()
    {
        Route route = _network.GenerateRandomRoute();

        _network.TakeAndInsert(route, 2, 4);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
        Assert.That(route.Duration, Is.EqualTo(_network.TravelTime(route)));
        
        _network.TakeAndInsert(route, 3, 1);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
        Assert.That(route.Duration, Is.EqualTo(_network.TravelTime(route)));
    }
}