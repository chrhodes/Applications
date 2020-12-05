using System.Windows;
using System.Windows.Controls;
using LineStatusViewer.ViewModels;

namespace LineStatusViewer.Views
{
    /// <summary>
    /// Interaction logic for LineStatusGridView
    /// </summary>
    public partial class LineStatusGridView : UserControl
    {
        private LineStatusViewModel _viewModel;

        public LineStatusGridView(LineStatusViewModel viewModel)
        {
            // 15
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += LineStatusView_Loaded;
        }

        //void LineStatusView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _viewModel.Load();
        //}

        async void LineStatusView_Loaded(object sender, RoutedEventArgs e)
        {
            // 37
            await _viewModel.LoadAsync();
        }
    }
}
