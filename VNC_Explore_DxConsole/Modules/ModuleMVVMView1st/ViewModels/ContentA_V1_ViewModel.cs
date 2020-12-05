using ModuleInterfaces;
using VNC.Core.Mvvm;

namespace ModuleMVVMView1st
{
    public class ContentA_V1_ViewModel : IContentAViewModel
    {
        // View 1st approach.  
        // ViewModel is not passed a View in constructor
        public ContentA_V1_ViewModel()
        {

        }

        private string _Message = "ContentA_V1";

        public string Message
        {
            get { return _Message; }
            set { _Message = value; } // Should implement INotifyPropertyChanged and set value
        }

        public IView View { get; set; }
    }
}
