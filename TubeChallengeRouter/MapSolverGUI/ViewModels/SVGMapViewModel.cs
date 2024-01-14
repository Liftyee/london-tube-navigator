using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace MapSolverGUI.ViewModels;

public class SVGMapViewModel : ReactiveObject
{
    private string? _StationName;
    public ICommand TestDirectCommand { get; }
    // use observablecollection so the UI is automatically updated when it changes
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
    
    public SVGMapViewModel()
    {
        this.WhenAnyValue(o => o.StationName);
        TestDirectCommand = ReactiveCommand.Create(OpenThePodBayDoors);
    }

    public string? StationName
    {
        get
        {
            return _StationName;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _StationName, value);
        }
    }

    private void OpenThePodBayDoors()
    {
        ConversationLog.Clear();
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
    }
}