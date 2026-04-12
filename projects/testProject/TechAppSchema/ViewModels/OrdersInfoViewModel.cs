using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TechAppSchema.Models;
using TechAppSchema.Views;

namespace TechAppSchema.ViewModels;

public partial class OrdersInfoViewModel : ViewModelBase
{
    [ObservableProperty]
    private Order _selectedOrder;

    [ObservableProperty]
    private ObservableCollection<Order> _orders = new()
        {
            new() {Id = 1, CreationTime = DateTime.Now.AddDays(-5).AddHours(-2).AddMinutes(-54), LineNumber = 1, Product = _seed, Weight = 7.2f, Status = "Производство"},
            new() {Id = 2, CreationTime = DateTime.Now.AddDays(-15).AddHours(-7).AddMinutes(-90), LineNumber = 1, Product = _seed, Weight = 5.6f, Status = "Подготовка"},
            new() {Id = 3, CreationTime = DateTime.Now.AddDays(-2).AddHours(-10).AddMinutes(-3), LineNumber = 1, Product = _manure, Weight = 1.2f, WeightType = "т.", Status = "Производство"},
            new() {Id = 4, CreationTime = DateTime.Now.AddDays(-20).AddHours(-3).AddMinutes(-13), LineNumber = 1, Product = _manure, Weight = 2.5f, WeightType = "т.", Status = "Подготовка"},
            new() {Id = 5, CreationTime = DateTime.Now.AddDays(-7).AddHours(-2).AddMinutes(-5), LineNumber = 1, Product = _sprout, Weight = 3.1f, Status = "Подготовка"},
        };

    [RelayCommand]
    private void OpenOrderCard()
    {
        OrderCardView orderCard = new(SelectedOrder);
    }

    private static Product _seed = new() { Id = 1, Name = "Семена"};
    private static Product _manure = new() { Id = 2, Name = "Удобрения"};
    private static Product _sprout = new() { Id = 3, Name = "Росток"};

    public OrdersInfoViewModel()
    {
        _orders = new()
        {
            new() {Id = 1, CreationTime = DateTime.Now.AddDays(-5).AddHours(-2).AddMinutes(-54), LineNumber = 1, Product = _seed, Weight = 7.2f},
            new() {Id = 2, CreationTime = DateTime.Now.AddDays(-15).AddHours(-7).AddMinutes(-90), LineNumber = 1, Product = _seed, Weight = 5.6f},
            new() {Id = 3, CreationTime = DateTime.Now.AddDays(-2).AddHours(-10).AddMinutes(-3), LineNumber = 1, Product = _manure, Weight = 1.2f, WeightType = "т."},
            new() {Id = 4, CreationTime = DateTime.Now.AddDays(-20).AddHours(-3).AddMinutes(-13), LineNumber = 1, Product = _manure, Weight = 2.5f, WeightType = "т."},
            new() {Id = 5, CreationTime = DateTime.Now.AddDays(-7).AddHours(-2).AddMinutes(-5), LineNumber = 1, Product = _sprout, Weight = 3.1f},
        };
    }
}
