using PrismApp1.ViewModels;

using System.Windows;

using VNC;

namespace PrismApp1.Presentation.Views
{
    public partial class MainWindowDx : Window
    {
        public MainWindowDxViewModel _viewModel;

        public MainWindowDx(MainWindowDxViewModel viewModel)
        {
            long startTicks = Log.Trace($"Enter", Common.PROJECT_NAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindowDx_Loaded;

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        // Load ViewModel asynchronously

        private async void MainWindowDx_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // Use this is have Collections in ViewModel
            //_viewModel.Load();
            //await _viewModel.LoadAsync();

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }
    }
}
