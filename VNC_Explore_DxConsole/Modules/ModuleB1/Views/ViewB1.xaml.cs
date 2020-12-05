using Prism.Regions;
using System.Windows.Controls;
using VNC.Core.Mvvm;

namespace ModuleB1
{
    public partial class ViewB1 : UserControl
    {
        public ViewB1()
        {
            InitializeComponent();
        }
    }

    public partial class ViewB1 : UserControl, IView, INavigationAware
    {
        public ViewB1(IViewB1ViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
