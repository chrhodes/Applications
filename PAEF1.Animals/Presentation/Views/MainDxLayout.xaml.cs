using System;
using System.Windows;

using PAEF1.Animals.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1.Animals.Presentation.Views
{
    public partial class MainDxLayout : ViewBase, IMain
    {
        public MainDxLayoutViewModel _viewModel;

        public MainDxLayout(MainDxLayoutViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
