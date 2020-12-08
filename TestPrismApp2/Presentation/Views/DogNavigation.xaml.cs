using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace TestPrismApp2.Presentation.Views
{
    /// <summary>
    /// Interaction logic for DogNavigation.xaml
    /// </summary>
    public partial class DogNavigation : UserControl, INavigation
    {
        public DogNavigation()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
