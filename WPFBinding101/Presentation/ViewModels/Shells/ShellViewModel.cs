using System;

using VNC;
using VNC.Core.Mvvm;

namespace .Presentation.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {

        private string _title = " - Shell";

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

        public ShellViewModel()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public ShellViewModel(I customerDataService)
        //{
        //    //_customerDataService = customerDataService;

        //    //Customers = new ObservableCollection<Customer>();
        //}

    }
}
