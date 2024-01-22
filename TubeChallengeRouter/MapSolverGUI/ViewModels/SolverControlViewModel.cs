using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;

namespace MapSolverGUI.ViewModels;

public class SolverControlViewModel : ReactiveObject
{
    private string? _startStationName;
    private double _solveProgress;
    public ICommand SolveCommand { get; }
    public ICommand TestControls { get; }
    public ObservableCollection<string> OutputLog { get; } = new ObservableCollection<string>();

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

    public SolverControlViewModel()
    {
        SolveCommand = ReactiveCommand.CreateFromTask(RunSolve);
        TestControls = ReactiveCommand.CreateFromTask(TestOutputs);
    }

    private async Task RunSolve()
    {
        
    }

    private async Task TestOutputs()
    {
        OutputLog.Add("Testing...");
        for (int i = 0; i <= 100; i++)
        {
            SolveProgress = i;
            await Task.Delay(10); // ms
        }
        OutputLog.Add("Done!");
    }
}