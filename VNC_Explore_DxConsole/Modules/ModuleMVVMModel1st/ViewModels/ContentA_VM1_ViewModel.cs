using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleMVVMViewModel1st
{
    public class ContentA_VM1_ViewModel : IContentAViewModel
    {
        private string _Message = "ContentA_VM1";

        // ViewModel first approach.  
        // View is passed in constructor

        public ContentA_VM1_ViewModel(IContentA view)
        {
            View = view;
            // Point the view to this ViewModel
            View.ViewModel = this;
        }

        public IView_VM1 View
        {
            get;
            set;
        }
      
        public string Message
        {
            get { return _Message; }
            set { _Message = value; } // Should implement INotifyPropertyChanged and set value
        }

        IView IViewModel.View { get; set; }
    }
}
