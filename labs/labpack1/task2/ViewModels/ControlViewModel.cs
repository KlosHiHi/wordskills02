using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.ViewModels
{
    public partial class ControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private double opacity = 1.0;

        [ObservableProperty]
        private string selectedLanguage;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Age))]
        private DateTime selectedDate = DateTime.Now;

        public List<string> Languages { get; set; } = ["С++", "С#", "С", "TypeScript", "JavaScript", "Kotlin"];  

        public int Age => DateTime.Now.Year - selectedDate.Year;
    }
}
