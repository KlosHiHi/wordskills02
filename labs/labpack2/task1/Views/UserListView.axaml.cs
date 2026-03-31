using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using task1.ViewModels;

namespace task1.Views;

public partial class UserListView : UserControl
{
    public UserListView()
    {
        InitializeComponent();
        DataContext = new UserListViewModel();
    }
}