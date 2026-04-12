using System;
using System.Data.Common;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TechAppSchema.ViewModels;

namespace TechAppSchema.Views;

public partial class OrdersInfoView : UserControl
{
    private OrdersInfoViewModel _viewModel = new();
    public OrdersInfoView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}