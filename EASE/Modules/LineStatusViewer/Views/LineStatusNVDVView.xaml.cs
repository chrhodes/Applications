using LineStatusViewer.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LineStatusViewer.Views
{
    public partial class LineStatusNVDVView : UserControl
    {
        private LineStatusNVDVViewModel _viewModel;

        public LineStatusNVDVView(LineStatusNVDVViewModel viewModel)
        {
            try
            {
                // 23
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
            // 33
            await _viewModel.LoadAsync();
        }
    }
}
