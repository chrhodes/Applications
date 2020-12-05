using ModulePeopleViewerLooseCoupling;
using System.Windows.Controls;

namespace ModulePeopleViewerLooseCoupling
{
    /// <summary>
    /// Interaction logic for PeopleViewer.xaml
    /// </summary>
    public partial class PeopleViewer : UserControl
    {
        // Problem.  PeopleViewer is tightly coupled to PeopleViewerViewModel
        // It has a direct reference to the PeopleViewerViewModel class.
        // Which must exist and be compiled for PeopleViewer to work.
        // PeopleViewer must also manage lifetime of PeopleViewerViewModel
        // NB. This comment is a bit odd given that PeopleViewer is a module
        // that contains a View and ViewModel.

        //public PeopleViewer()
        //{
        //    InitializeComponent();

        //    // Can either use AutoWireUp by using this line in the Xaml
        //    //prism: ViewModelLocator.AutoWireViewModel = "True"
        //    // or explicitly create and bind the ViewModel

        //    DataContext = new ViewModels.PeopleViewerViewModel();
        //}

        // Pass in the viewModel so we are no longer coupled
        // Could get fancy and do an interface, but since View and ViewModel are 
        // in same class here, let's keep it simple.

        public PeopleViewer(PeopleViewerViewModel viewModel)
        {
            InitializeComponent();

            // Can either use AutoWireUp by using this line in the Xaml
            //prism: ViewModelLocator.AutoWireViewModel = "True"
            // or explicitly create and bind the ViewModel

            //DataContext = new ViewModels.PeopleViewerViewModel();
            DataContext = viewModel;
        }
    }
}
