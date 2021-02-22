using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

using WPFBinding101.Presentation.ViewModels;

namespace WPFBinding101.Presentation.Views
{
    public partial class MainDxDockLayoutManager : ViewBase, IMain
    {
        public MainDxDockLayoutManagerViewModel _viewModel;

        public MainDxDockLayoutManager(MainDxDockLayoutManagerViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
