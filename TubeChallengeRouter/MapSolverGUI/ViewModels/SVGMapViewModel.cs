using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls.Skia;
using ReactiveUI;
using SkiaSharp;

namespace MapSolverGUI.ViewModels;

public class SVGMapViewModel : ReactiveObject
{
    private string? _StationName;
    private bool _ShowSVG;
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

    public bool showSVG
    {
        get
        {
            return _ShowSVG;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _ShowSVG, value);
        }
    }

    private void OpenThePodBayDoors()
    {
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
        showSVG = !showSVG; // update the public one to make changes visible
    }
    
    public void CanvasControl_OnDraw(object? sender, SKCanvasEventArgs e)
    {
        e.Canvas.DrawRect(SKRect.Create(0f, 0f, 100f, 100f), new SKPaint { Color = SKColors.Aqua });
    }
}