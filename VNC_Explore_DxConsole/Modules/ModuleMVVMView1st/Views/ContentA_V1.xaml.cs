using System.Windows.Controls;
using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleMVVMView1st
{
    public partial class ContentA_V1 : UserControl, IContentA
    {
        // View 1st approach.  
        // ViewModel is passed in constructor
        // Container must create ViewModel first so it can be passed in.

        public ContentA_V1(IContentAViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IContentAViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

        IViewModel IView.ViewModel { get; set; }
    }
}
