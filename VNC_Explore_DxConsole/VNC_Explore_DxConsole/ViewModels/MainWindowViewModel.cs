using Prism.Mvvm;

namespace VNC_Explore_DxConsole.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "VNC Explore Console";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
