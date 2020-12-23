using System;
using System.Windows;

using PrismAppEF1.ViewModels;

using VNC;

namespace PrismAppEF1.Presentation.Views
{
    public partial class MainWindowDxLayout : Window
    {
        public MainWindowDxLayoutViewModel _viewModel;

        public MainWindowDxLayout(MainWindowDxLayoutViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

    }
}
