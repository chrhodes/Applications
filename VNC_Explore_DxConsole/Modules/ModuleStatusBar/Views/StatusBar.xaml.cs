using VNC.Core.Mvvm;
using ModuleInterfaces;
using System.Windows.Controls;

namespace ModuleStatusBar
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
    }
}
