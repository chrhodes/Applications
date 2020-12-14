using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Views
{
    /// <summary>
    /// Interaction logic for ProjectNavigation.xaml
    /// </summary>
    public partial class ProjectNavigation : UserControl, INavigation
    {
        public ProjectNavigation()
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
