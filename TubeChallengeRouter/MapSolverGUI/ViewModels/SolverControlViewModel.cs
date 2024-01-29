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
using Serilog.Core;
using Serilog.Events;
using SkiaSharp;
using SkiaSharp.HarfBuzz;
using TransportNetwork;

namespace MapSolverGUI.ViewModels;

public class SolverControlViewModel : ReactiveObject
{
    private string? _startStationName;
    private double _solveProgress;
    private double _swapProb;
    private double _tempFactor;
    private int _maxIterations;
    private ISolver solver;
    public ICommand SolveCommand { get; }
    public ICommand TestControls { get; }
    public ObservableCollection<string> OutputLog { get; } = new ObservableCollection<string>();
    
    private static UIOutputSink UILogger { get; } = new UIOutputSink();
    private static ILogger logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.Sink(UILogger, LogEventLevel.Information)
        .CreateLogger();
    
    internal class UIOutputSink : ILogEventSink
    {
        private ObservableCollection<string>? outputLog;
        
        public void Emit(LogEvent logEvent)
        {
            if (outputLog == null)
            {
                throw new NullReferenceException("Tried to log but Output log not set");
            }
            
            outputLog.Add(logEvent.RenderMessage());
        }

        public void AddOutput(ObservableCollection<string> output)
        {
            outputLog = output;
        }
    }

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
            solver.SetRandomSwapProbability(value);
            this.RaiseAndSetIfChanged(ref _swapProb, value);
        }
    }
    
    public double TempFactor
    {
        get
        {
            return _tempFactor;
        }
        set
        {
            solver.SetCoolDownFactor(value);
            this.RaiseAndSetIfChanged(ref _tempFactor, value);
        }
    }
    
    public int MaxIterations
    {
        get
        {
            return _maxIterations;
        }
        set
        {
            solver.SetMaxIterations(value);
            this.RaiseAndSetIfChanged(ref _maxIterations, value);
        }
    }

    public SolverControlViewModel()
    {
        logger.Information("Hello World! Logging is {Description}.","online");
        UILogger.AddOutput(OutputLog);
        solver = new AnnealingSolver(logger, SetProgress);
        SwapProb = solver.GetRandomSwapProbability();
        TempFactor = solver.GetCoolDownFactor();
        MaxIterations = solver.GetMaxIterations();

        SolveCommand = ReactiveCommand.CreateFromTask(SolveRouteAsync);
        TestControls = ReactiveCommand.CreateFromTask(TestOutputs);
    }

    private void RunSolve()
    {
        INetworkDataFetcher fetcher = new TflModelWrapper(logger, GetCachePath());
        fetcher.SetProgressCallback(SetProgress);
        NetworkFactory tubeFactory = new NetworkFactory(fetcher);
        Network tube;
        try
        {
            tube = tubeFactory.Generate(NetworkType.Dijkstra, logger);
        }
        catch (IO.Swagger.Client.ApiException)
        {
            logger.Error("Could not fetch Tube network data. Try checking your internet connection.");
            throw new Exception("Couldn't fetch data from API.");
        }
        logger.Debug("Result: {A}",tube.ToString());
        
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
        OutputLog.Add($"Generating route with {MaxIterations} iterations and temperature factor {TempFactor.ToString("0.###")}...");
        try
        {
            await Task.Run(() => RunSolve());
        }
        catch (Exception e)
        {
            OutputLog.Add($"Error while solving: {e.Message}");
            logger.Debug("Exception while solving: {A}", e);
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
    
    private static string GetCachePath()
    {
        // work out the cache path in a platform-agnostic way
        string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        const string furtherPath = ".cache/TubeNetworkCache/"; // Linux standard but works for Windows too
        return Path.Combine(homeDir, furtherPath);
    }
}