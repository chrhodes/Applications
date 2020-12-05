using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleToolBar
{
    public class ToolBarViewModel : ViewModelBase, IToolBarViewModel
    {
        public ToolBarViewModel(IToolBar view)
            : base(view)
        {

        }

        IView IViewModel.View { get; set; }
    }
}
