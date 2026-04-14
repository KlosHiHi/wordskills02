using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Views;

public partial class MainView : UserControl
{
    private MainViewModel _viewModel = new();
    public MainView()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.Title = (sender as Button).Content.ToString();
        _viewModel.Content = null!;
    }
}   
