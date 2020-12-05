using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Dog.Views
{
    public partial class DogDetail : UserControl, IDogDetail
    {
        public DogDetail(ViewModels.IDogDetailViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
