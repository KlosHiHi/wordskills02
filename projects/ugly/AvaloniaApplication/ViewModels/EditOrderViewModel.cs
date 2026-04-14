using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using TechAppSchema.Models;

namespace AvaloniaApplication.ViewModels;

public partial class EditOrderViewModel(Order order) : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<string> _products = new()
    {
        "Семена", "Ростки", "Удобрения"
    };

    [ObservableProperty]
    private ObservableCollection<string> _weigthTypes = new()
    {
        "кг.", "т."
    };

    [ObservableProperty]
    private ObservableCollection<int> _lines = new()
    {
        1, 2, 3
    };

    [ObservableProperty]
    private Order _order = order;
}
