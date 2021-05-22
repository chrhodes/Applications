using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

using WPFTestBed.Presentation.ViewModels;

namespace WPFTestBed.Presentation.Views
{
    public partial class Main
    {
        public MainViewModel _viewModel;

        public Main()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeComponent();

            DataContext = new MainViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Main(MainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
