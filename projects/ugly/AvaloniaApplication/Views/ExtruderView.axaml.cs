using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Views;

public partial class ExtruderView : UserControl
{
    private ExtruderViewModel _viewModel = new();
    public ExtruderView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}