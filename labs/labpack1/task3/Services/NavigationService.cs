using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task3.ViewModels;

namespace task3.Services
{
    public class NavigationService
    {
        public ViewModelBase CurrentPage=>pageStack.Peek();

        private Stack<ViewModelBase> pageStack = new();

        public void NavigateTo<T>(T viewmodel, Action<T>? action = null) where T : ViewModelBase
        {
            pageStack.Push(viewmodel);
            action?.Invoke(viewmodel);
        }

        public void GoBack(int steps = 1)
        {
            pageStack.Pop();
        }
    }
}
