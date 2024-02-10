using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using DataFetcher;
using ReactiveUI;
using RouteSolver;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using TransportNetwork;

namespace MapSolverGUI.ViewModels;

public class SolverControlViewModel : ReactiveObject
{
    private string? _startStationName;
    private double _solveProgress;
    private double _swapProb;
    private double _tempFactor;
    private int _maxIterations;
    private readonly ISolver _solver;
    private INetworkDataSource _source;
    private NetworkFactory _tubeFactory;
    private Network? _tube;
    public ICommand SolveCommand { get; }
    public ObservableCollection<string> OutputLog { get; } = new ObservableCollection<string>();
    
    private static UiOutputSink UiLogger { get; } = new UiOutputSink();
    private static readonly ILogger Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.Sink(UiLogger, LogEventLevel.Information)
        .CreateLogger();
    
    private class UiOutputSink : ILogEventSink
    {
        private ObservableCollection<string>? _outputLog;
        
        public void Emit(LogEvent logEvent)
        {
            if (_outputLog == null)
            {
                throw new NullReferenceException("Tried to log but Output log not set");
            }
            
            _outputLog.Add(logEvent.RenderMessage());
        }

        public void AddOutput(ObservableCollection<string> output)
        {
            _outputLog = output;
        }
    }

    public double SolveProgress
    {
        get => _solveProgress;
        set => this.RaiseAndSetIfChanged(ref _solveProgress, value);
    }

    public string? StartStation
    {
        get => _startStationName;
        set => this.RaiseAndSetIfChanged(ref _startStationName, value);
    }
    
    public double SwapProb
    {
        get => _swapProb;
        set
        {
            _solver.SetRandomSwapProbability(value);
            this.RaiseAndSetIfChanged(ref _swapProb, value);
        }
    }
    
    public double TempFactor
    {
        get => _tempFactor;
        set
        {
            _solver.SetCoolDownFactor(value);
            this.RaiseAndSetIfChanged(ref _tempFactor, value);
        }
    }
    
    public int MaxIterations
    {
        get => _maxIterations;
        set
        {
            _solver.SetMaxIterations(value);
            this.RaiseAndSetIfChanged(ref _maxIterations, value);
        }
    }

    public SolverControlViewModel()
    {
        Logger.Information("Hello World! Logging is {Description}.","online");
        UiLogger.AddOutput(OutputLog);
        _solver = new AnnealingSolver(Logger, SetProgress);
        SwapProb = _solver.GetRandomSwapProbability();
        TempFactor = _solver.GetCoolDownFactor();
        MaxIterations = _solver.GetMaxIterations();

        SolveCommand = ReactiveCommand.CreateFromTask(SolveRouteAsync);
        
        InitializeNetwork();
    }

    private void InitializeNetwork()
    {
        if (_tube is not null)
        {
            return;
        }
        _source = new TflModelWrapper(Logger, GetCachePath());
        _source.SetProgressCallback(SetProgress);
        _tubeFactory = new NetworkFactory(_source);
        try
        {
            _tube = _tubeFactory.Generate(NetworkType.Dijkstra, Logger);
        }
        catch (IO.Swagger.Client.ApiException)
        {
            Logger.Error("Could not fetch Tube network data. Try checking your internet connection.");
            throw new Exception("Couldn't fetch data from API.");
        }
        Logger.Debug("Result: {A}",_tube.ToString());
    }

    private void RunSolve()
    {
        InitializeNetwork();
        
        Route route = _solver.Solve(_tube);
        Logger.Debug("Route: {A} (duration {B})",_tube.RouteToStringStationSeq(route), route.Duration);

        WriteRouteToFile(_tube, route);
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
        OutputLog.Add($"Generating route with {MaxIterations} iterations and temperature factor {TempFactor:0.###}...");
        try
        {
            await Task.Run(RunSolve);
        }
        catch (Exception e)
        {
            OutputLog.Add($"Error while solving: {e.Message}");
            Logger.Debug("Exception while solving: {A}", e);
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

    private void WriteRouteToFile(Network tube, Route route)
    {
        // generate a unique filename
        var now = DateTime.Now;
        string dateCode = $"{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}";
        string outputPath = $"{GetCachePath()}route{dateCode}.txt";

        // write the route directly to the filestream
        using var file = new FileStream(outputPath, FileMode.Create);
        tube.RouteDetailsToStream(route, file);
        Logger.Information("Result written to {A}", outputPath);
    }
}