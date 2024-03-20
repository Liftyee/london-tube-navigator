using NUnit.Framework.Interfaces;

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
        
        // As of Mar 2024, the Tube network has unique 273 station IDs
        Assert.That(tubeNetwork.GetStationIDs().Count, Is.EqualTo(273)); 
        
        // Check that each station has a name and ID
        foreach (string stationId in tubeNetwork.GetStationIDs())
        {
            Assert.That(tubeNetwork.GetStationName(stationId), Is.Not.Null);
        }
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

    [Test]
    public void TflDataSource_CallsProgressCallback()
    {
        bool callbackFired = false;
        // dummy callback to pass to TflModelWrapper, to check if it's called
        void Callback(double progress)
        {
            callbackFired = true;
        }
        
        TflModelWrapper dataSource = new TflModelWrapper(stubLogger, "./");
        dataSource.SetProgressCallback(Callback); 
        
        Network tubeNetwork = new NetworkFactory(dataSource)
            .Generate(NetworkType.Dijkstra, stubLogger);
        
        // The progress callback should have fired at least once
        Assert.That(callbackFired, Is.True); 
    }
}