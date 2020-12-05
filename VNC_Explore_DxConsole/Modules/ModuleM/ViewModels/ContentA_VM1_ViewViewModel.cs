using ModuleInterfaces;
using VNC.Core.Mvvm;

namespace ModuleM
{
    public class ContentA_VM1_ViewViewModel : IContentA_VM1_ViewViewModel
    {
        private string _Message = "ContentA_VM1";

        // ViewModel first approach.  
        // View is passed in constructor

        public ContentA_VM1_ViewViewModel(IContentA_VM1_View view)
        {
            View = view;
            // Point the view to this ViewModel
            View.ViewModel = this;
        }

        public IView View
        {
            get;
            set;
        }
      
        public string Message
        {
            get { return _Message; }
            set { _Message = value; } // Should implement INotifyPropertyChanged and set value
        }
    }
}
