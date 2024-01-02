using TransportNetwork;

namespace StationTests;

[TestFixture]
public class LinkTests
{
    private Station _stubStation1, _stubStation2;
    private Link _link;
    
    [SetUp]
    public void SetUp()
    {
        _stubStation1 = new Station("A", "Station A");
        _stubStation2 = new Station("B", "Station B");
        _link = new Link(_stubStation1, _stubStation2, null, Dir.Inbound);
    }

    [Test]
    public void Constructor_SetsDetails()
    {
        Assert.That(_link.Origin, Is.SameAs(_stubStation1));
        Assert.That(_link.Destination, Is.SameAs(_stubStation2));
        Assert.That(_link.Line, Is.Null);
        Assert.That(_link.Dir, Is.EqualTo(Dir.Inbound));
        Assert.That(_link.Duration, Is.EqualTo(new TimeSpan(0,1,0)));
    }

    [Test]
    public void SetDuration_ChangesDurationAttribute()
    {
        _link.SetDuration(new TimeSpan(0, 5, 0));
        Assert.That(_link.Duration, Is.EqualTo(new TimeSpan(0,5,0)));
    }

    [Test]
    public void SetLine_ChangesLineAttribute()
    {
        Line line = new Line("line1", "Line 1");
        _link.SetLine(line);
        Assert.That(_link.Line, Is.SameAs(line));
    }

    [Test]
    public void SetDurationMoreThanOnce_ThrowsException()
    {
        _link.SetDuration(new TimeSpan(0, 5, 0));
        Assert.Throws<InvalidOperationException>(() => _link.SetDuration(new TimeSpan(0, 5, 0)));
    }

    [Test]
    public void SetLineMoreThanOnce_ThrowsException()
    {
        Line line = new Line("line1", "Line 1");
        _link.SetLine(line);
        Assert.Throws<InvalidOperationException>(() => _link.SetLine(line));
    }
}