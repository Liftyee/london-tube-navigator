namespace StationTests;

[TestFixture]
public class DataSourceTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void TfLDataSource_PopulatesNetwork()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        Network tubeNetwork = new NetworkFactory(
                new TflModelWrapper(stubLogger, "./"))
                            .Generate(NetworkType.Dijkstra, stubLogger);
        
        // As of Mar 2024, the Tube network has 273 station IDs
        Assert.That(tubeNetwork.GetStationIDs().Count, Is.EqualTo(273)); 
    }
}