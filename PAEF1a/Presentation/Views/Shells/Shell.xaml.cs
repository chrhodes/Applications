using System;
using System.Windows;

using PAEF1a.Presentation.ViewModels;

using VNC;

namespace PAEF1a.Presentation.Views
{
    public partial class Shell : Window
    {
        public ShellViewModel _viewModel;

        public Shell(ShellViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }
    }
}
