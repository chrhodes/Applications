using VNC.Core.Mvvm;
using ModuleInterfaces;
using System.Windows.Controls;

namespace ModuleStatusBarEventAggregation
{
    public partial class StatusBar : UserControl, IStatusBar
    {
        public StatusBar()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        IViewModel IView.ViewModel { get; set; }
    }
}
