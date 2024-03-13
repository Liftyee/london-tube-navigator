namespace RouteSolver.Tests;

public class SolverTests
{
    private Network _net;
    private AnnealingSolver _solver;
    [SetUp]
    public void Setup()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        NetworkFactory factory = new NetworkFactory(new LinearNetwork(10));
        _net = factory.Generate(NetworkType.Floyd, stubLogger);
        _solver = new AnnealingSolver(stubLogger);
        
    }

    [Test]
    public void Solver_GeneratesSolution()
    {
        Route result = _solver.Solve(_net);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Solver_SettingsChange()
    {
        _solver.SetMaxIterations(50000);
        
        Route result = _solver.Solve(_net);
        Assert.That(result, Is.Not.Null);
    }
}