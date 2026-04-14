using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using TechAppSchema.Models;

namespace AvaloniaApplication.ViewModels;

public partial class OrderListViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isEditVisible = false;

    [ObservableProperty]
    private ViewModelBase _editPage;

    [ObservableProperty]
    private ObservableCollection<Order> _orders;

    private List<Product> _productList = new() { 
        new(){Id = 1, Name = "Семена"},
        new() { Id = 2, Name = "Удобрения"},
        new() { Id = 3, Name = "Росток"},
    };

    public OrderListViewModel()
    {
        _orders = new()
        {
            new() {Id = 1, CreationTime = DateTime.Now.AddDays(-5).AddHours(-2).AddMinutes(-54), 
            LineNumber = 2, Product = _productList[0], Weight = 7.2f, Status = "Черновик", Recipe = new(), TechCard = new()},
            new() {Id = 2, CreationTime = DateTime.Now.AddDays(-15).AddHours(-7).AddMinutes(-90), 
            LineNumber = 1, Product = _productList[2], Weight = 5.6f, Status = "Закрыт", Recipe = new()},
            new() {Id = 3, CreationTime = DateTime.Now.AddDays(-2).AddHours(-10).AddMinutes(-3), 
            LineNumber = 3, Product = _productList[1], Weight = 1.2f, WeightType = "т.", Status = "Готов"},
            new() {Id = 4, CreationTime = DateTime.Now.AddDays(-20).AddHours(-3).AddMinutes(-13), 
            LineNumber = 1, Product = _productList[1], Weight = 2.5f, WeightType = "т.", Status = "Черновик"},
            new() {Id = 5, CreationTime = DateTime.Now.AddDays(-7).AddHours(-2).AddMinutes(-5), 
            LineNumber = 2, Product = _productList[2], Weight = 3.1f, Status = "Черновик", TechCard = new()},
        };
    }

    [RelayCommand]
    private void CloseEdit()
    {
        IsEditVisible = !IsEditVisible;
    }

    [RelayCommand]
    private async Task EditOrderAsync(Order order)
    {
        IsEditVisible = order.Status == "Черновик";
        
        if(IsEditVisible)
        {
            EditPage = new EditOrderViewModel(order);
            return;
        }

        await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заказ уже готов", icon:MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
    }

    [RelayCommand]
    private async Task SuccessOrder(Order order)
    {
        var message = MessageBoxManager.GetMessageBoxStandard(
            "Поддтверждение удаления",
            "Вы действительно хотите изменить статус заказа?",
            MsBox.Avalonia.Enums.ButtonEnum.YesNo,
            MsBox.Avalonia.Enums.Icon.Warning
        );

        try
        {
            var result = await message.ShowAsync();

        if(result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {          
            if (order.Weight > 0)
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Объём заказа не может быть нулевым", icon:MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                return;
            }

            if (order.Recipe is null)
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка", "К заказу не привязана рецептура", icon:MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                return;
            }

            if (order.TechCard is null)
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка", "К заказу не привязана тех. карта", icon:MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                return;
            }

            order.Status = "Готов";
            var o = Orders.FirstOrDefault(o=>o.Id == order.Id);
            Orders.Remove(o);
            Orders.Add(order);
        }  
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
