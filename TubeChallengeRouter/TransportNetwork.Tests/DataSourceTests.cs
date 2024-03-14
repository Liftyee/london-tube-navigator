namespace StationTests;

[TestFixture]
public class DataSourceTests
{
    private ILogger stubLogger;
    [SetUp]
    public void Setup()
    {
        stubLogger = new LoggerConfiguration().CreateLogger();
    }

    [Test]
    public void TfLDataSource_PopulatesNetwork()
    {
        Network tubeNetwork = new NetworkFactory(
                new TflModelWrapper(stubLogger, "./"))
                            .Generate(NetworkType.Dijkstra, stubLogger);
        
        // As of Mar 2024, the Tube network has 273 station IDs
        Assert.That(tubeNetwork.GetStationIDs().Count, Is.EqualTo(273)); 
    }

    [Test]
    public void LinearNetwork_CorrectNumNodes()
    {
        for (int i = 1; i < 20; i += 5)
        {
            Network linearNetwork = new NetworkFactory(new LinearNetwork(i))
                .Generate(NetworkType.Dijkstra, stubLogger);
            Assert.That(linearNetwork.GetStationIDs().Count, Is.EqualTo(i));
        }
    }
}