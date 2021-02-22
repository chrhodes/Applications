using System;

using VNC;
using VNC.Core.Mvvm;

namespace WPFBinding101.Presentation.Views
{
    public partial class BirdNavigation : ViewBase, IBirdNavigation, IInstanceCountV
    {
        public BirdNavigation()
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
