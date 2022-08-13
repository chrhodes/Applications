using System;
using System.Windows;

using PAEF3.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF3.Presentation.Views
{
    public partial class Shell : Window, IInstanceCountV
    {
        public ShellViewModel _viewModel;

        public Shell(ShellViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
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
