using System;
using System.Windows;

using .Presentation.ViewModels;

using VNC;

namespace .Presentation.Views
{
    public partial class RibbonShell : Window
    {
        public RibbonShellViewModel _viewModel;

        public RibbonShell(RibbonShellViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }
    }
}
