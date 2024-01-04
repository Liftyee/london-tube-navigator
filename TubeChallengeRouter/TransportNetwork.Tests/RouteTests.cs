using TransportNetwork;

namespace StationTests;

[TestFixture]
public class RouteTests
{
    private Route _route;
    
    [SetUp]
    public void SetUp()
    {
        _route = new Route(new List<string> {"A", "B", "C"}, new TimeSpan(0,10,0));
    }

    [Test]
    public void TestExternalEditRoute_ChangesInternalRoute()
    {
        List<string> path = _route.GetTargetPath();
        string temp = path[1];
        path[1] = path[2];
        path[2] = temp;
        Assert.That(_route.GetTargetPath(), Is.EqualTo(new List<string> {"A", "C", "B"}));
    }
}