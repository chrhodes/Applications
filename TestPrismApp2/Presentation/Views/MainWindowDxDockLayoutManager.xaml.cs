using System;
using System.Windows;

using TestPrismApp2.ViewModels;

using VNC;

namespace TestPrismApp2.Presentation.Views
{
    public partial class MainWindowDxDockLayoutManager : Window
    {
        public MainWindowViewModel _viewModel;

        public MainWindowDxDockLayoutManager(MainWindowViewModel viewModel)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindow_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // Load ViewModel asynchronously

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //_viewModel.Load();
            //await _viewModel.LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
