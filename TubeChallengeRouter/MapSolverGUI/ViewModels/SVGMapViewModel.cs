using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia.Controls.Skia;
using ReactiveUI;
using SkiaSharp;
using Svg.Skia;

namespace MapSolverGUI.ViewModels;

public class SvgMapViewModel : ReactiveObject
{
    private string? _stationName;
    private bool _showSvg;
    public ICommand TestCommand { get; }
    // use observablecollection so the UI is automatically updated when it changes
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    private SKSvg _svgMap;

    private SKSvg SvgMap
    {
        get
        {
            return _svgMap;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _svgMap, value);
        }
    }
    
    private Avalonia.Svg.Skia.Svg _svg;

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
    
    public SvgMapViewModel()
    {
        // find the assets directory and switch to it
        System.IO.Directory.GetCurrentDirectory();
        while (!System.IO.Directory.GetCurrentDirectory().EndsWith("MapSolverGUI"))
        {
            System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory())!.FullName);
        }
        System.IO.Directory.SetCurrentDirectory(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Assets"));
        
        this.WhenAnyValue(o => o.StationName);
        TestCommand = ReactiveCommand.Create(OpenThePodBayDoors);

        SvgMap = new SKSvg();
        //svgMap.Load("/home/yee/tubemapgrouped.svg");
        SvgMap.Load("svglogo.svg");
        //UpdateSVG();
    }

    public string? StationName
    {
        get
        {
            return _stationName;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _stationName, value);
        }
    }

    public bool ShowSvg
    {
        get
        {
            return _showSvg;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _showSvg, value);
        }
    }

    public void UpdateSvg()
    {
        Stopwatch sw = new();
        string svgtext = System.IO.File.ReadAllText("groupedmap.svg");
        sw.Start();
        SvgMap.FromSvg(svgtext);
        this.RaisePropertyChanged(nameof(SvgMap));
        Console.WriteLine($"SVG loaded in {sw.ElapsedMilliseconds} ms");
    }
    
    private void OpenThePodBayDoors()
    {
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
        ShowSvg = !ShowSvg; // update the public one to make changes visible
    }
    
    public void CanvasControl_OnDraw(object? sender, SKCanvasEventArgs e)
    {
        //e.Canvas.DrawRect(SKRect.Create(0f, 0f, 100f, 100f), new SKPaint { Color = SKColors.Aqua });
        e.Canvas.DrawPicture(SvgMap.Picture);
    }
    
    private void HideGroup(SKCanvas canvas, string groupId)
    {

    }

    private void HideSvg()
    {
        
    }
}