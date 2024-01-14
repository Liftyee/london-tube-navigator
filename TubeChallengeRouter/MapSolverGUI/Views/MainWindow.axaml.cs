using System.Runtime.InteropServices.ComTypes;
using Avalonia.Controls;
using Avalonia.Controls.Skia;
using SkiaSharp;
using MapSolverGUI.ViewModels;

namespace MapSolverGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new SVGMapViewModel();
        
        if (DataContext is SVGMapViewModel viewModel)
        {
            CanvasControl.Draw += viewModel.CanvasControl_OnDraw;
        }
    }
}