using ModuleInterfaces;
using System.Windows.Controls;
using VNC.Core.Mvvm;

namespace ModuleSBN
{
    /// <summary>
    /// Interaction logic for ContentA.xaml
    /// </summary>
    public partial class ContentSBN : UserControl, IContentSBN
    {
        public ContentSBN(IContentSBNViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IContentSBNViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
