using Avalonia.Controls;

namespace MapSolverGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // DataContext = new SvgMapViewModel();
        //
        // if (DataContext is SvgMapViewModel viewModel)
        // {
        //     CanvasControl.Draw += viewModel.CanvasControl_OnDraw;
        // }
    }
}