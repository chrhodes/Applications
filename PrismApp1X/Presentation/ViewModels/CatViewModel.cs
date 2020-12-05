using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;

using PrismApp1.DomainServices;
using PrismApp1.Presentation.ModelWrappers;

using Unity;

using VNC;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ViewModels
{
    public class CatViewModel : ViewModelBase, ICatViewModel
    {
        private ICatLookupDataService _catLookupDataService;
        private ICatDataService _catDataService;

        #region Constructors and Load

        // View First
        // View creates new ViewModel in code or Xaml
        // or ViewModel passed into View constructor

        [InjectionConstructor]
        public CatViewModel(
            ICatLookupDataService CatLookupDataService,
            ICatDataService CatDataServcie)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // TODO(crhodes)
            // Decide if we want defaults
            //Cat = new CatWrapper(new Domain.Cat());

            _catLookupDataService = CatLookupDataService;
            _catDataService = CatDataServcie;

            Cats = new ObservableCollection<CatWrapper>();

            InitializeViewModel();

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        // ViewModel First
        // Calling base(view) wires this ViewModel into the View

        public CatViewModel(Views.Cat view) : base(view)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeViewModel();

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            //var lookup = await _catLookupDataService.GetCatsLookupAsync();

            var cats = await _catDataService.AllAsync();

            Cats.Clear();

            foreach (var cat in cats)
            {
                //Customers.Add(item);
                Cats.Add(new CatWrapper(cat));
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // TODO(crhodes)
            // Initialize any controls and/or properties that need to be

            DoSomethingCommand = new DelegateCommand(OnDoSomethingExecute, OnDoSomethingCanExecute);
            DoSomethingContent = "Update Actions for selected shapes";
            DoSomethingToolTip = "ToolTip for DoSomething Button";

            Message_DoubleClick_Command = new DelegateCommand(Message_DoubleClick);

            //InitializeRows();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Fields

        #endregion

        #region Properties

        string _message = "Click Button to do something";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        // TODO(crhodes)
        // This is for a Grid or List

        // public System.Collections.ObjectModel.ObservableCollection<string> SelectedFruits { get; set; }

        public ObservableCollection<CatWrapper> Cats { get; set; }

        // and the SelectedItem in the Grid or List

        CatWrapper _selectedItem;
        public CatWrapper SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        //Don't forget to uncomment InitializeRows in InitializeViewModel()

         void InitializeRows()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            Cats = new ObservableCollection<CatWrapper>();
            Cats.Add(new CatWrapper(new Domain.Cat() 
                { FieldString = "Nikki", FieldInt = 1 , FieldDate=DateTime.Now, FieldDouble=89.1, FieldSingle=1.89F}));
            Cats.Add(new CatWrapper(new Domain.Cat() 
                { FieldString = "Nelli", FieldInt = 2, FieldDate = DateTime.Now, FieldDouble = 99.1, FieldSingle = 1.99F }));
            Cats.Add(new CatWrapper(new Domain.Cat() 
                { FieldString = "Archer", FieldInt = 3, FieldDate = DateTime.Now, FieldDouble = 109.1, FieldSingle = 1.109F }));

            OnPropertyChanged("Rows");

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Commands

        #region DoSomething Command

        public DelegateCommand DoSomethingCommand { get; set; }
        public string DoSomethingContent { get; set; }
        public string DoSomethingToolTip { get; set; }

        public void OnDoSomethingExecute()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // TODO(crhodes)
            // Do something amazing.

            Message = "Cool, you did something!";

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool OnDoSomethingCanExecute()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            // TODO(crhodes)
            // Add any before button is enabled logic.

            Log.Trace($"Exit (true)", Common.LOG_APPNAME, startTicks);

            return true;
        }

        #endregion

        #region Control Commands (Not Buttons)

        public DelegateCommand Message_DoubleClick_Command { get; set; }

        public void Message_DoubleClick()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            Message = "Message DoubleClicked!";

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #endregion Commands

    }
}
