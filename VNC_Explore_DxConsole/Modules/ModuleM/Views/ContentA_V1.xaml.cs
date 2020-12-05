using ModuleInterfaces;
using System.Windows.Controls;
using VNC.Core.Mvvm;

namespace ModuleM
{
    /// <summary>
    /// Interaction logic for ContentA2.xaml
    /// This is for View first approaches
    /// </summary>
    public partial class ContentA_V1 : UserControl, IContentA_V1_View
    {
        // View first approach.  ViewModel is passed in constructor
        // Container must create ViewModel first so it can be passed in.

        public ContentA_V1(IContentA_V1_ViewViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                //return (IViewModel2)DataContext;
                return (IContentA_V1_ViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

        IViewModel IView.ViewModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
