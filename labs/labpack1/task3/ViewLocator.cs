using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using task3.ViewModels;

namespace task3
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public Control? Build(object? data)
        {
            var name = data?.GetType().FullName?.Replace("ViewModel", "View");

            var type = Type.GetType(name ?? "");

            return (type is not null)
                ? (Control?)Activator.CreateInstance(type)
                : new TextBlock { Text = $"Not Fount: {name}" };
        }

        public bool Match(object data) => data is ViewModelBase;
    }
}
