using System;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1.Presentation.ViewModels
{
    public class MainDxLayoutViewModel : ViewModelBase, IMainWindowViewModel
    {
        private string _title = "PAEF1 - MainWindowDxLayout";

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public MainDxLayoutViewModel()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

    }
}
