using ModuleInterfaces;
using System;
using VNC.Core.Mvvm;

namespace ModuleM
{
    public class ContentA_V1_ViewViewModel : IContentA_V1_ViewViewModel
    {
        // View first approach.  ViewModel is not passed a View in constructor
        public ContentA_V1_ViewViewModel()
        {

        }

        private string _Message = "ContentA_V1";

        public string Message
        {
            get { return _Message; }
            set { _Message = value; } // Should implement INotifyPropertyChanged and set value
        }

        public IView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
