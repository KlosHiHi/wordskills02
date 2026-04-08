using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary.Options;
using CommunityToolkit.Mvvm.Input;
using TechApp.Models;

namespace TechApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private async Task SaveExcel()
    {
        var users = await HttpClientOptions.Client.GetFromJsonAsync<List<User>>($"{HttpClientOptions.BaseUrl}user/") ?? null!;
        await ExportService.ExportToExcel(users, "file.xlsx");
    }
}
