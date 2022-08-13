using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF2.Presentation.Views
{
    public partial class CarMain : ViewBase, ICarMain, IInstanceCountV
    {

        public CarMain(ViewModels.ICarMainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += UserControl_Loaded;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(CarMain) Enter", Common.LOG_CATEGORY);

            await ((ViewModels.ICarMainViewModel)ViewModel).LoadAsync();

            Log.EVENT_HANDLER("(CarMain) Exit", Common.LOG_CATEGORY, startTicks);
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
