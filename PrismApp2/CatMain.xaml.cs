using System;
using System.Windows;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.Views
{
    public partial class CatMain : UserControl, ICatMain
    {

        public CatMain(ViewModels.ICatMainViewModel viewModel)
        {
            Int64 startTicks = Log.Trace($"Enter({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();

            ViewModel = viewModel;
            Loaded += UserControl_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await ((ViewModels.ICatMainViewModel)ViewModel).LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
