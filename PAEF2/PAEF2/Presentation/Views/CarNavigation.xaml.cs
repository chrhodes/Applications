using System;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF2.Presentation.Views
{
    public partial class CarNavigation : ViewBase, ICarNavigation, IInstanceCountV
    {
        public CarNavigation()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
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
