using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace WPFBinding101.Presentation.Views
{
    public partial class BirdMain : ViewBase, IBirdMain, IInstanceCountV
    {

        public BirdMain(ViewModels.IBirdMainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += UserControl_Loaded;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(BirdMain) Enter", Common.LOG_APPNAME);

            await ((ViewModels.IBirdMainViewModel)ViewModel).LoadAsync();

            Log.EVENT_HANDLER("(BirdMain) Exit", Common.LOG_APPNAME, startTicks);
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
