using Prism.Mvvm;

namespace EASECommandConsole.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "EASE Command Console";
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
