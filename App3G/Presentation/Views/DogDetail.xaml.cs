using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace App3.Presentation.Views
{
    public partial class DogDetail : UserControl, IDogDetail
    {
        public static int _instanceCountDV = 0;

        public DogDetail()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _instanceCountDV++;
            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public DogDetail(ViewModels.IDogDetailViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();
            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public int InstanceCountDV
        {
            get { return _instanceCountDV; }
            set { _instanceCountDV = value; }
        }
    }
}
