using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace App3.Presentation.Views
{
    public partial class Navigation : UserControl, INavigation
    {
        private static int _instanceCountV = 0;

        public Navigation()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _instanceCountV++;
            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public int InstanceCountV
        {
            get { return _instanceCountV; }
            set { _instanceCountV = value; }
        }
    }
}
