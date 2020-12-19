using System;
using System.Windows;

using App3.ViewModels;

using VNC;

namespace App3.Presentation.Views
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

            Loaded += MainWindowDxLayout_Loaded;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // Load ViewModel asynchronously

        private async void MainWindowDxLayout_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            //_viewModel.Load();
            //await _viewModel.LoadAsync();

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
