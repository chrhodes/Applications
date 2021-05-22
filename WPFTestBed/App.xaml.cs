using System;
using System.Windows;

using VNC;

namespace WPFTestBed
{
    public partial class App : Application
    {

        #region Event Handlers

        private void Application_DispatcherUnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Error("Unexpected error occurred. Please inform the admin."
              + Environment.NewLine + e.Exception.Message, Common.LOG_CATEGORY);

            MessageBox.Show("Unexpected error occurred. Please inform the admin."
              + Environment.NewLine + e.Exception.Message, "Unexpected error");

            e.Handled = true;
        }

        #endregion

    }
}
