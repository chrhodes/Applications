using System;
using System.Windows;

using VNC;

namespace PrismApp1.Presentation.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            InitializeComponent();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
