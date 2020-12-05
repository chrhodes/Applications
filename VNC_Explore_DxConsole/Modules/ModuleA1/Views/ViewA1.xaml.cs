using Prism.Regions;
using System.Windows.Controls;
using VNC.Core.Mvvm;

namespace ModuleA1
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA1 : UserControl
    {
        public ViewA1()
        {
            InitializeComponent();
        }
    }

    public partial class ViewA1 : UserControl, IView, INavigationAware
    {
        public ViewA1(IViewA1ViewModel viewModel)
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
