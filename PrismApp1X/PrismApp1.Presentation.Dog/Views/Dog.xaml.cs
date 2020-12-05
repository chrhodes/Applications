using System.Windows;
using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Dog.Views
{
    public partial class Dog : UserControl, IDog
    {

        public Dog(ViewModels.IDogViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += Dog_Loaded;
        }

        private async void Dog_Loaded(object sender, RoutedEventArgs e)
        {
            await ((ViewModels.IDogViewModel)ViewModel).LoadAsync();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
