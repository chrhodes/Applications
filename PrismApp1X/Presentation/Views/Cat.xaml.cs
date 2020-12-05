using System;
using System.Windows;
using System.Windows.Controls;

using PrismApp1.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Views
{
    public partial class Cat : UserControl, IView, ICat
    {
        #region Constructors and Load

        // View First.  
        // View is passed ViewModel through Injection
        // or can declare ViewModel in Xaml or Code

        // ViewModel First.  
        // ViewModel creates View 
        // and sets DataContext by setting ViewModel property

        public Cat()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeComponent();

            // If View First with ViewModel in Xaml
            // Expose ViewModel
            // ViewModel = (ICatViewModel)DataContext;

            // Can create directly
            // ViewModel = new CatViewModel();

            InitializeView();

            Loaded += Cat_Loaded;

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        private async void Cat_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            await ((ViewModels.ICatViewModel)ViewModel).LoadAsync();

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        public Cat(ICatViewModel viewModel)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeComponent();

            ViewModel = viewModel;

            InitializeView();

            Loaded += Cat_Loaded;

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        private void InitializeView()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // TODO(crhodes)
            // Perform any initialization or configuration of View

            //lgMain.IsCollapsed = true;

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        #endregion

        #region Properties

        private IViewModel _viewModel;

        public IViewModel ViewModel
        {
            get { return _viewModel; }

            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        #endregion
    }
}
