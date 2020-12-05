using System.Windows.Controls;
using VNC.Core.Mvvm;

namespace ModuleM
{
    /// <summary>
    /// Interaction logic for ContentA.xaml
    /// This is for ViewModel first approaches
    /// </summary>
    public partial class ContentA_VM1 : UserControl, IContentA_VM1_View
    {
        public ContentA_VM1()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IContentA_VM1_ViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
