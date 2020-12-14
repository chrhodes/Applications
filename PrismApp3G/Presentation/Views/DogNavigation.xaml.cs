using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp3.Presentation.Views
{
    public partial class DogNavigation : UserControl, IDogNavigation
    {
        public DogNavigation()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
