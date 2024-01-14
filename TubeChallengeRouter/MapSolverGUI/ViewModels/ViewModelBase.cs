using System;
using ReactiveUI;

namespace MapSolverGUI.ViewModels;

public class ViewModelBase : ReactiveObject
{
}

public class ReactiveViewModel : ReactiveObject
{
    public ReactiveViewModel()
    {
        // We can listen to any property changes with "WhenAnyValue" and do whatever we want in "Subscribe".
        this.WhenAnyValue(o => o.Name)
            .Subscribe(new Action<object>(o => this.RaisePropertyChanged(nameof(Greeting))));
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
            // ReactiveUI function to raise (notify) the UI if anything changed and also set our backing field
            this.RaiseAndSetIfChanged(ref _Name, value);
        }
    }
    
    public string Greeting
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
            {
                // If no Name is provided, use a default Greeting
                return "Hello World from Avalonia.Samples";
            }
            else
            {
                // else greet the User.
                return $"Hello {Name}";
            }
        }
    }
}