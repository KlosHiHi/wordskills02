using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Views;

public partial class FormulationsView : UserControl
{
    private FormulationsViewModel _viewModel = new();
    public FormulationsView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    private void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var dataGrid = (DataGrid)sender;
        var selected = dataGrid.SelectedItem;
        if(selected != null)
        {
            
        }
    }
}