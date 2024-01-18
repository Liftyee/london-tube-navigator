namespace StationTests;

public class NetworkTests
{
    private Network _network;

    [SetUp]
    public void SetUp()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        ILogger consoleLogger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .CreateLogger();
        _network = new NetworkFactory(new TestNetwork1()).Generate(NetworkType.Dijkstra, consoleLogger);
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

    [Test]
    public void SwapInsert_UpdatesRoute()
    {
        
    }

    [Test]
    public void VerifyTestNetworkCosts()
    {
        // links:
        // A > B, B > C, B > D, C > E, D > E (all cost 1)
        Assert.That(_network.CostFunction("A","B"), Is.EqualTo(1*60));
        Assert.That(_network.CostFunction("A","C"), Is.EqualTo(2*60));
        Assert.That(_network.CostFunction("A","D"), Is.EqualTo(2*60));
        Assert.That(_network.CostFunction("A","E"), Is.EqualTo(3*60));
        
        Assert.That(_network.CostFunction("B","C"), Is.EqualTo(1*60));
        Assert.That(_network.CostFunction("B","D"), Is.EqualTo(1*60));
        Assert.That(_network.CostFunction("B","E"), Is.EqualTo(2*60));
        
        Assert.That(_network.CostFunction("C","D"), Is.EqualTo(2*60));
        Assert.That(_network.CostFunction("C","E"), Is.EqualTo(1*60));
        
        Assert.That(_network.CostFunction("D","E"), Is.EqualTo(1*60));
    }

    [Test]
    public void TestNetwork_CostSymmetric()
    {
        foreach (string stationA in _network.GetStationIDs())
        {
            foreach (string stationB in _network.GetStationIDs())
            {
                Assert.That(_network.CostFunction(stationA, stationB), Is.EqualTo(_network.CostFunction(stationB, stationA)));
            }
        }
    }

    [Test]
    public void RecalculateRoute_DataAccurate()
    {
        Route genRoute = _network.GenerateRandomRoute();
        Route newRoute = new Route(genRoute.TargetStations);
        _network.RecalculateRouteData(ref newRoute);
        Assert.That(newRoute.Cost, Is.EqualTo(genRoute.Cost));
        Assert.That(newRoute.Duration, Is.EqualTo(genRoute.Duration));
        Assert.That(newRoute.TargetStations, Is.EqualTo(genRoute.TargetStations));
        Assert.That(newRoute.IntermediateStations, Is.EqualTo(genRoute.IntermediateStations));
    }
}