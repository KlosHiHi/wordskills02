using System;
using TechAppSchema.Models;

namespace TechAppSchema.ViewModels;

public partial class OrderCardViewModel(Order order) : ViewModelBase
{
    private Order _order = order;
}
