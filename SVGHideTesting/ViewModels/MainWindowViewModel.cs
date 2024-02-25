using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Xml.Linq;
using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using SkiaSharp;

namespace SVGHideTesting.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    
    private Bitmap _svgImage;
    public Bitmap SvgImage
    {
        get => _svgImage;
        set => this.RaiseAndSetIfChanged(ref _svgImage, value);
    }

    private string _svgSource;
    
    public string SvgSource
    {
        get => _svgSource;
        set => this.RaiseAndSetIfChanged(ref _svgSource, value);
    }
    
    public ReactiveCommand<Unit, Unit> ToggleElementsCommand { get; }

    public MainWindowViewModel()
    {
        // Load SVG file
        var svgDoc = XDocument.Load("/home/yee/tubemap.svg");
        
        ToggleSvgElements(svgDoc);
        // Command to toggle elements
        ToggleElementsCommand = ReactiveCommand.Create(() =>
        {
            ToggleSvgElements(svgDoc);
        });
    }

    private void ToggleSvgElements(XDocument svgDoc)
    {
        // Example: Toggling elements based on some condition
        var rects = svgDoc.Descendants().Where(e => e.Name.LocalName == "g" && e.Attribute("id").Value == "940GZZLUHSD"); // Select all rect elements
        foreach (var rect in rects)
        {
            // Example: Toggle based on some condition
            var isVisible = ShouldElementBeVisible(rect);
            rect.SetAttributeValue("visibility", isVisible ? "visible" : "hidden");
        }

        SvgSource = svgDoc.ToString();
    }

    private bool visible;

    private bool ShouldElementBeVisible(XElement element)
    {
        // Example predicate: Toggle every other element
        // Modify this predicate based on your specific requirements
        // var index = element.ElementsBeforeSelf().Count();
        // return index % 2 == 0;
        visible = !visible;
        return visible;
    }
}