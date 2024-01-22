using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using DataFetcher;
using ReactiveUI;
using RouteSolver;
using Serilog;
using SkiaSharp.HarfBuzz;
using TransportNetwork;

namespace MapSolverGUI.ViewModels;

public class SolverControlViewModel : ReactiveObject
{
    private string? _startStationName;
    private double _solveProgress;
    private double _swapProb;
    private ISolver solver;
    public ICommand SolveCommand { get; }
    public ICommand TestControls { get; }
    public ICommand SetSwapProbCmd { get; }
    public ObservableCollection<string> OutputLog { get; } = new ObservableCollection<string>();
    private static ILogger logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();
    

    public double SolveProgress
    {
        get
        {
            return _solveProgress;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _solveProgress, value);
        }
    }

    public string? StartStation
    {
        get
        {
            return _startStationName;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _startStationName, value);
        }
    }
    
    public double SwapProb
    {
        get
        {
            return _swapProb;
        }
        set
        {
            this.SetSwapProb(value);
            this.RaiseAndSetIfChanged(ref _swapProb, value);
        }
    }

    public SolverControlViewModel()
    {
        logger.Information("Hello World! Logging is {Description}.","online");
        solver = new AnnealingSolver(logger, SetProgress);

        SolveCommand = ReactiveCommand.CreateFromTask(SolveRouteAsync);
        TestControls = ReactiveCommand.CreateFromTask(TestOutputs);
        SetSwapProbCmd = ReactiveCommand.Create<double>(prob => SetSwapProb(prob));
    }

    private void RunSolve()
    {
        NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger, GetCachePath()));
        Network tube = tubeFactory.Generate(NetworkType.Dijkstra, logger);
        logger.Information("Result: {A}",tube.ToString());
        //logger.Debug(tube.EnumerateStations());
        
        Route route = solver.Solve(tube);
        logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);

        // TODO: extract this output code to a function
        var now = DateTime.Now;
        string datecode = $"{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}";
        string outputpath = $"{GetCachePath()}route{datecode}.txt";
        // write route to a file
        using (var file = new FileStream(outputpath, FileMode.Create))
        {
            tube.RouteDetailsToStream(route, file);
            logger.Information("Result written to {A}", outputpath);
        }
        ShowSolverResult(route);
    }

    private async Task TestOutputs()
    {
        OutputLog.Add("Testing...");
        for (int i = 0; i <= 100; i++)
        {
            SolveProgress = i;
            await Task.Delay(50); // ms
        }
        OutputLog.Add("Done!");
    }

    private async Task SolveRouteAsync()
    {
        try
        {
            await Task.Run(() => RunSolve());
        }
        catch (Exception e)
        {
            OutputLog.Add($"Error while solving: {e.Message}");
        }
    }

    private void ShowSolverResult(Route result)
    {
        OutputLog.Add($"Result: Route with {result.Duration.TotalMinutes} minutes and {result.InterStationCount()} intermediate stations.");
    }
    
    private void SetProgress(double progress)
    {
        SolveProgress = progress;
    }

    private void SetSwapProb(double prob)
    {
        solver.SetRandomSwapProbability(prob);
    }
    
    private static string GetCachePath()
    {
        // work out the cache path in a platform-agnostic way
        string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        const string furtherPath = ".cache/TubeNetworkCache/"; // Linux standard but works for Windows too
        return Path.Combine(homeDir, furtherPath);
    }
}