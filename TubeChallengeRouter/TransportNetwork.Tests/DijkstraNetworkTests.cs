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
            _network.CostFunction(result.TargetStations[idx], result.TargetStations[idx + 1], out dijResult);
            Assert.That(result.IntermediateStations[idx], Is.EqualTo(dijResult));
        }
    }

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
        // TotalSeconds should always be an integer, since the smallest unit we use is seconds
        Assert.That((int)route.Duration.TotalSeconds == _tubeNetwork.CostFunction(route));

        Route smallRoute = _network.GenerateRandomRoute();
        Assert.That((int)smallRoute.Duration.TotalSeconds == _network.CostFunction(smallRoute));
    }
    [Test]
    public void TubeNetwork_RouteCostEqualToSegmentSum()
    {
        // use solver (move to different file?)
    }
}