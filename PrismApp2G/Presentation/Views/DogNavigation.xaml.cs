using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.Views
{
    /// <summary>
    /// Interaction logic for DogNavigation.xaml
    /// </summary>
    public partial class DogNavigation : UserControl, IDogNavigation
    {
        public DogNavigation()
        {
            Int64 startTicks = Log.CONSTRUCTOR(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
