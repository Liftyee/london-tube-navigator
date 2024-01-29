using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MapSolverGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    public SimpleViewModel SimpleViewModel { get; } = new SimpleViewModel();
    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
    public SvgMapViewModel SvgMapViewModel { get; } = new();
    public SolverControlViewModel SolverControlViewModel { get; } = new();
}

public class SimpleViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    // [CallerMemberName] provides the property name for us so we don't have to when we RaisePropertyChanged();.
    private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string? _name;

    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            // only notify the UI if the name actually changed.
            if (_name != value)
            {
                _name = value;
                
                // We call this to notify the UI about changes. 
                RaisePropertyChanged();
                
                RaisePropertyChanged(nameof(Greeting));
            }
        }
    }

    public string Greeting
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
            {
                // If no Name is provided, use a default value.
                return "Hello World from Avalonia.Samples";
            }
            else
            {
                return $"Hello {Name}";
            }
        }
    }
}