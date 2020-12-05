using System.Windows;
using System.Windows.Controls;

namespace PrismApp1.Resources.Xaml
{
    public partial class MenuButton_Styles
    {
        public void DisplayUserControlFromTag(object sender, RoutedEventArgs e)
        {
            ////string controlName = ((Button)sender).Tag.ToString();
            //string typeName = ((Button)sender).Tag.ToString();

            //// TODO(crhodes)
            //// Put this string in config or Common.

            ////string typeName = string.Format("VNCCodeCommandConsole.User_Interface.User_Controls.{0}",
            ////                controlName);

            //try
            //{
            //    Type ucType = Type.GetType(typeName);
            //    var uc = Activator.CreateInstance(ucType);

            //    //if (controlName == "wucDX_Databases")
            //    //{
            //    //    ((Databases)uc).DisplayOptions = new EyeOnLife.User_Interface.Content_Controls.cc2();
            //    //}

            //    ShowUserControl((UserControl)uc);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        string.Format("Cannot load type:{0}.  Check Tag Name.\n {1}",
            //        typeName,
            //        ex));
            //}
        }

        private void ShowUserControl(UserControl control)
        {
            // TODO(crhodes)
            // Need to search for dbUserControlContainer to make this work.

            //dpUserControlContainer.Children.Clear();

            //if (control != null)
            //{
            //    dpUserControlContainer.Children.Add(control);
            //    _currentControl = control;
            //}

            //HookTitleEvent(_currentControl);
        }
    }
}
