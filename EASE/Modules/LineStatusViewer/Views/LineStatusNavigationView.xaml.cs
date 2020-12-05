using LineStatusViewer.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LineStatusViewer.Views
{

    public partial class LineStatusNavigationView : UserControl
    {
         public LineStatusNavigationView()
        {
            InitializeComponent();
        }

        private LineStatusNavigationViewModel _viewModel;

        public LineStatusNavigationView(LineStatusNavigationViewModel viewModel)
        {
            try
            {
                InitializeComponent();

                _viewModel = viewModel;
                DataContext = _viewModel;

                Loaded += LineStatusView_Loaded;
            }
            catch (Exception ex)
            {
                var foo = ex;
            }
        }

        async void LineStatusView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
