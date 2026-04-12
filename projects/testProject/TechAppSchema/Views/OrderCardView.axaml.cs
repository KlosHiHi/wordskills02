using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TechAppSchema.Models;
using TechAppSchema.ViewModels;

namespace TechAppSchema.Views;

public partial class OrderCardView : UserControl
{
    private Order _order;
    private OrderCardViewModel _viewModel ;
    public OrderCardView(Order order)
    {
        _order = order;
        _viewModel = new(_order);
        InitializeComponent();
        DataContext = _viewModel;
    }
}