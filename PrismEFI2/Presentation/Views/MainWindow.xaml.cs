using System;
using System.Windows;

using PrismEFI2.ViewModels;

using VNC;

namespace PrismEFI2.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel _viewModel;

        public MainWindow(MainWindowViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
