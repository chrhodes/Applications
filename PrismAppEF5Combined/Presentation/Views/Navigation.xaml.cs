using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace PrismAppEF5.Presentation.Views
{
    public partial class Navigation : ViewBase, INavigation, IInstanceCountV
    {

        public Navigation()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountV++;
            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion

    }
}
