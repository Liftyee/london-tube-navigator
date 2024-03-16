namespace StationTests;

public class Tests
{
    private Station _stat1, _stat2;
    [SetUp]
    public void Setup()
    {
        _stat1 = new Station("A", "Station A");
        _stat2 = new Station("B"); // use both constructors
    }

    [Test]
    public void Constructor_SetsNaptan()
    {
        Assert.That(_stat1.NaptanId, Is.EqualTo("A"));
        Assert.That(_stat2.NaptanId, Is.EqualTo("B"));
    }

    [Test]
    public void Constructor_SetsName()
    {
        Assert.That(_stat1.Name, Is.EqualTo("Station A"));
        Assert.That(_stat2.Name, Is.Null);
    }
    
    [Test]
    public void AddingLink_UpdatesGetLinks()
    {
        Link link = new Link(_stat2, null, Dir.Inbound);
        _stat1.AddLink(link);
        Assert.That(_stat1.GetLinks(), Is.EquivalentTo(new List<Link>{link}));
    }
    
    [Test]
    public void AddingLink_UpdatesHasLink()
    {
        Link link = new Link(_stat2, null, Dir.Inbound);
        _stat1.AddLink(link);
        Assert.That(_stat1.HasLink("B"), Is.True);
    }
}