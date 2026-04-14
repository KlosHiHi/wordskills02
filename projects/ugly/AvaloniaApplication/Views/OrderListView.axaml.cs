using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Views;

public partial class OrderListView : UserControl
{
    private OrderListViewModel _viewModel = new();
    public OrderListView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}