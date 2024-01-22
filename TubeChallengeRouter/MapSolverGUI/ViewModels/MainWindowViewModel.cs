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
    public SVGMapViewModel SVGMapViewModel { get; } = new();
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

    private string? _Name;

    public string? Name
    {
        get
        {
            return _Name;
        }
        set
        {
            // only notify the UI if the name actually changed.
            if (_Name != value)
            {
                _Name = value;
                
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