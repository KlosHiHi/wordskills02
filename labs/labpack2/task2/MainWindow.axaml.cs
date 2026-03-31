using Avalonia.Controls;

namespace task2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var key = App.Configuration.GetSection("ApiKeys")["SomeApi"];
            KeyTextBlock.Text = key;        
        }
    }
}