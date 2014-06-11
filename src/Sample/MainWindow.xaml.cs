using System.Windows;

namespace Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainWindowViewModel();
            vm.Init();

            this.DataContext = vm;
        }
    }
}
