using System.Windows.Controls;
using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleToolBar
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolBar : UserControl, IToolBar
    {
        public ToolBar()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        IViewModel IView.ViewModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
