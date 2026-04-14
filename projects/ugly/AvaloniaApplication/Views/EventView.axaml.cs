using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Views;

public partial class EventView : UserControl
{
    private EventViewModel _viewModel = new();
    public EventView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}