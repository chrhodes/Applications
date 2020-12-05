using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModuleStatusBar
{
    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        public StatusBarViewModel(IStatusBar view)
            : base(view)
        {
        }

        private string _message = "Ready";
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
    }
}

