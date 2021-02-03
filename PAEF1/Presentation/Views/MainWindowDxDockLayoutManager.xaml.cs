using System;
using System.Windows;

using PAEF1.Presentation.ViewModels;

using VNC;

namespace PAEF1.Presentation.Views
{
    public partial class MainWindowDxDockLayoutManager : Window
    {
        public MainWindowDxDockLayoutManagerViewModel _viewModel;

        public MainWindowDxDockLayoutManager(MainWindowDxDockLayoutManagerViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
