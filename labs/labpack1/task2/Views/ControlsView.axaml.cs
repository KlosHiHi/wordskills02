using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using task2.ViewModels;

namespace task2.Views;

public partial class ControlsView : UserControl
{
    public ControlsView()
    {
        InitializeComponent();
        DataContext = new ControlViewModel();
    }
}