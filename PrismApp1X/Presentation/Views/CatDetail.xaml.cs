using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Views
{
    public partial class CatDetail : UserControl, ICatDetail
    {
        public CatDetail(ViewModels.ICatDetailViewModel viewModel)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeComponent();
            ViewModel = viewModel;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
