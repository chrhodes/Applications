using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.Views
{
    public partial class DogDetail : UserControl, IDogDetail
    {

        public DogDetail()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public DogDetail(ViewModels.IDogDetailViewModel viewModel)
        {
            Int64 startTicks = Log.Trace($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();
            ViewModel = viewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
