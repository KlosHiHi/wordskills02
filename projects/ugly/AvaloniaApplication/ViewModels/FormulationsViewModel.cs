using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary.Options;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication.ViewModels;

public partial class FormulationsViewModel : ViewModelBase
{
    [ObservableProperty]
    private List<Formulation> _formulations;

    public FormulationsViewModel()
    {
        GetData();
    }

    private async Task GetData()
    {
        var responce = await HttpOption.httpClient.GetFromJsonAsync<List<Formulation>>($"{HttpOption.baseUrl}formulation");
        Formulations = responce;
    }
}
