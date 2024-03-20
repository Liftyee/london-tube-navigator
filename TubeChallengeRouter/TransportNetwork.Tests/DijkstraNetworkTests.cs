namespace StationTests;

[TestFixture]
public class DijkstraNetworkTests
{
    private Network _network;
    private Network _tubeNetwork;
    
    [SetUp]
    public void SetUp()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        _network = new NetworkFactory(new TestNetwork1()).Generate(NetworkType.Dijkstra, stubLogger);
        _tubeNetwork = new NetworkFactory(new TflModelWrapper(stubLogger, "./")).Generate(NetworkType.Dijkstra, stubLogger);
    }

    [Test]
    public void Dijkstra_FindsPath()
    {
        int result = _network.CostFunction("A", "E");
        Assert.That(result, Is.EqualTo(180)); // cost is in seconds
    }

    // Test that the Dijkstra cost function returns the correct intermediate stations
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
        // Debug.Assert(!path.Contains(startId));
        // Debug.Assert(!path.Contains(endId));
    }
    
    // Check that the intermediate stations are set for a new random route
    [Test]
    public void RandomRoute_HasIntermediate()
    {
        Route result = _network.GenerateRandomRoute();
        
        for (int idx = 0; idx < result.Count-1; idx++)
        {
            List<string> dijResult;
            _network.CostFunction(result.TargetStations[idx], result.TargetStations[idx + 1], out dijResult);
            Assert.That(result.InterStations[idx], Is.EqualTo(dijResult));
        }
    }
    
    // Directly linked stations should have no intermediates between them
    [Test]
    public void AdjacentStations_NoIntermediate()
    {
        List<string> inter;
        int cost = _network.CostFunction("A", "B", out inter);
        
        Assert.That(inter.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void TubeNetwork_AdjacentStationsNoIntermediate()
    {
        List<string> inter;
        int cost = _tubeNetwork.CostFunction("940GZZLUGPK", "940GZZLUHPC", out inter);
    }

    [Test]
    public void RandomRoute_CostAccurate()
    {
        Route route = _tubeNetwork.GenerateRandomRoute();
        Assert.That((int)route.Cost == _tubeNetwork.CostFunction(route));

        Route smallRoute = _network.GenerateRandomRoute();
        Assert.That((int)smallRoute.Cost == _network.CostFunction(smallRoute));
    }
    
    [Test]
    public void TubeNetwork_RouteCostEqualToSegmentSum()
    {
        // use solver (move to different file?)
    }

    [Test]
    public void Swap_SwapsStations()
    {
        Route route = new Route(new List<string> { "A", "B", "C", "D", "E" });
        _network.RecalculateRouteData(ref route);
        
        // edge case: last
        _network.Swap(ref route, 1, 4);
        Assert.That(route.TargetStations, Is.EqualTo(new List<string> { "A", "E", "C", "D", "B" }));
        
        // edge case: first
        _network.Swap(ref route, 0, 3);
        Assert.That(route.TargetStations, Is.EqualTo(new List<string> { "D", "E", "C", "A", "B" }));
        
        // just a normal swap
        _network.Swap(ref route, 2, 3);
        Assert.That(route.TargetStations, Is.EqualTo(new List<string> { "D", "E", "A", "C", "B" }));
        
        // swap with self
        _network.Swap(ref route, 2, 2);
        Assert.That(route.TargetStations, Is.EqualTo(new List<string> { "D", "E", "A", "C", "B" }));
    }

    [Test]
    public void Swap_UpdatesCosts()
    {
        Route route = new Route(new List<string> { "A", "B", "C", "D", "E" });
        _network.RecalculateRouteData(ref route);
        
        // edge case: last
        _network.Swap(ref route, 1, 4);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
        
        // edge case: first
        _network.Swap(ref route, 0, 3);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
        
        // just a normal swap
        _network.Swap(ref route, 2, 3);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
        
        // swap with self
        _network.Swap(ref route, 2, 2);
        Assert.That(route.Cost, Is.EqualTo(_network.CostFunction(route)));
    }

    [Test]
    public void Swap_UpdatesPath()
    {
        Route route = new Route(new List<string> { "A", "B", "C", "D", "E" });
        _network.RecalculateRouteData(ref route);
        
        // edge case: last
        _network.Swap(ref route, 1, 4);
        Assert.That(route.InterStations, Is.EqualTo(new List<List<string>> {new List<string>{"B","C"}, new List<string>(), new List<string>{"B"}, new List<string>()}));
        
        // TODO: finish this test
    }
}