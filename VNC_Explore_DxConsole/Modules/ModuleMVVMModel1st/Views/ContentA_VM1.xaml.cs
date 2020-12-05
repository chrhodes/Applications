using System.Windows.Controls;
using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleMVVMViewModel1st
{
    public partial class ContentA_VM1 : UserControl, IContentA
    {
        public ContentA_VM1()
        {
            InitializeComponent();
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
    }
}
