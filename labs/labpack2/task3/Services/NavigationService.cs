using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using task3.ViewModels;

namespace task3.Services
{
    public partial class NavigationService : ObservableObject
    {
        public ViewModelBase CurrentPage => _pageStack.Peek();

        private Stack<ViewModelBase> _pageStack = new();

        public void NavigateTo<T>(T viewmodel, Action<T>? action = null) where T : ViewModelBase
        {
            action?.Invoke(viewmodel);
            _pageStack.Push(viewmodel);
            OnPropertyChanged(nameof(CurrentPage));
        }

        public void NavigateTo<T>(Action<T>? action = null) where T : ViewModelBase
        {
            var viewModel = App.Services.GetRequiredService<T>();
            NavigateTo(viewModel, action);
        }

        public void GoBack(int steps = 1)
        {
            for (int i = 0; i < steps; i++)
                _pageStack.Pop();

            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
