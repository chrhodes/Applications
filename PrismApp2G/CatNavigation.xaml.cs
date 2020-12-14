using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.Views
{
    /// <summary>
    /// Interaction logic for CatNavigation.xaml
    /// </summary>
    public partial class CatNavigation : UserControl, ICatNavigation
    {
        public CatNavigation()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
