using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Input;
using Avalonia.Controls.Skia;
using ReactiveUI;
using SkiaSharp;
using Svg.Skia;

namespace MapSolverGUI.ViewModels;

public class SVGMapViewModel : ReactiveObject
{
    private string? _StationName;
    private bool _ShowSVG;
    public ICommand TestCommand { get; }
    // use observablecollection so the UI is automatically updated when it changes
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    private SKSvg _SvgMap;

    private SKSvg SvgMap
    {
        get
        {
            return _SvgMap;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _SvgMap, value);
        }
    }
    
    private Avalonia.Svg.Skia.Svg svg;

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
    
    public SVGMapViewModel()
    {
        // set current working dir to assets
        // System.IO.Directory.SetCurrentDirectory("/home/yee/RiderProjects/tube-challenge-router/MapSolverGUI/Assets");
        this.WhenAnyValue(o => o.StationName);
        TestCommand = ReactiveCommand.Create(OpenThePodBayDoors);

        SvgMap = new SKSvg();
        //svgMap.Load("/home/yee/tubemapgrouped.svg");
        SvgMap.Load("/home/yee/RiderProjects/tube-challenge-router/TubeChallengeRouter/MapSolverGUI/Assets/svglogo.svg");
        //UpdateSVG();
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

    public void UpdateSVG()
    {
        Stopwatch sw = new();
        string svgtext = System.IO.File.ReadAllText("/home/yee/RiderProjects/tube-challenge-router/TubeChallengeRouter/MapSolverGUI/Assets/groupedmap.svg");
        sw.Start();
        SvgMap.FromSvg(svgtext);
        this.RaisePropertyChanged(nameof(SvgMap));
        Console.WriteLine($"SVG loaded in {sw.ElapsedMilliseconds} ms");
    }
    
    private void OpenThePodBayDoors()
    {
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
        showSVG = !showSVG; // update the public one to make changes visible
    }
    
    public void CanvasControl_OnDraw(object? sender, SKCanvasEventArgs e)
    {
        //e.Canvas.DrawRect(SKRect.Create(0f, 0f, 100f, 100f), new SKPaint { Color = SKColors.Aqua });
        e.Canvas.DrawPicture(SvgMap.Picture);
    }
    
    private void HideGroup(SKCanvas canvas, string groupId)
    {

    }

    private void HideSVG()
    {
        
    }
}