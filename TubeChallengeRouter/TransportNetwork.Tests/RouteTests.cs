namespace StationTests;

[TestFixture]
public class RouteTests
{
    private Route _route;
    
    [SetUp]
    public void SetUp()
    {
        _route = new Route(new List<string> {"A", "B", "C"}, 3, new List<List<string>> {new List<string>(), new List<string> ()});
    }

    [Test]
    public void TestExternalEditRoute_ChangesInternalRoute()
    {
        List<string> path = _route.TargetStations;
        string temp = path[1];
        path[1] = path[2];
        path[2] = temp;
        Assert.That(_route.TargetStations, Is.EqualTo(new List<string> {"A", "C", "B"}));
    }
}