using System;

using System.Windows;

using VNC;

namespace TestPrismApp1.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
