using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleViewer
{
    /// <summary>
    /// Interaction logic for PeopleViewer.xaml
    /// </summary>
    public partial class PeopleViewer : UserControl
    {
        public PeopleViewer()
        {
            InitializeComponent();

            // Can either use AutoWireUp by using this line in the Xaml
            //prism: ViewModelLocator.AutoWireViewModel = "True"
            // or explicitly create and bind the ViewModel
            DataContext = new Presentation.PeopleViewerViewModel();
        }
    }
}
