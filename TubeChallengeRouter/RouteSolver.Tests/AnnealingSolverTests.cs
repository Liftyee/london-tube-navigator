namespace RouteSolver.Tests;

public class SolverTests
{
    private Network _net;
    private AnnealingSolver _solver;
    [SetUp]
    public void Setup()
    {
        ILogger stubLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        NetworkFactory factory = new NetworkFactory(new LinearNetwork(10));
        _net = factory.Generate(NetworkType.Dijkstra, stubLogger);
        _solver = new AnnealingSolver(stubLogger);
    }

    [Test]
    public void Solver_GeneratesOptimalSolution()
    {
        // The 10 node network is small enough that the optimal solution 
        // should always be found by the solver
        Route result = _solver.Solve(_net);
        Assert.That(result.Duration, Is.EqualTo(9));
    }
    
    // Test that the solver can handle changes to its settings.
    [Test]
    public void Solver_SettingsChange()
    {
        _solver.SetMaxIterations(50000);
        _solver.SetCoolDownFactor(0.95);
        _solver.SetRandomSwapProbability(0.5);
        
        Assert.That(_solver.GetMaxIterations(), Is.EqualTo(50000));
        Assert.That(_solver.GetCoolDownFactor(), Is.EqualTo(0.95));
        Assert.That(_solver.GetRandomSwapProbability(), Is.EqualTo(0.5));
        
        // Test that the solver still works after change to settings
        Route result = _solver.Solve(_net);
        Assert.Pass();
    }
    
    // Test that the solver calls its progress callback.
    [Test]
    public void Solver_CallsProgressCallback()
    {
        bool callbackFired = false;
        // dummy callback to pass to TflModelWrapper, to check if it's called
        void Callback(double progress)
        {
            callbackFired = true;
        }
        
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        _solver = new AnnealingSolver(stubLogger, Callback);
        _solver.Solve(_net);
        
        // The progress callback should have fired at least once
        Assert.That(callbackFired, Is.True); 
    }
    
    // Test that the solver generates a route with all the stations.
    [Test]
    public void GeneratedRoute_VisitsAll()
    {
        Route result = _solver.Solve(_net);
        List<string> stationIds = _net.GetStationIDs();
        foreach (string stationId in stationIds)
        {
            Assert.That(result.TargetStations.Contains(stationId), Is.True);
        }
    }
}