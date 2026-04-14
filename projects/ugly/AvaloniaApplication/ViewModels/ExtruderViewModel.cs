using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication.ViewModels;

public partial class ExtruderViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = "эструдер";
}
