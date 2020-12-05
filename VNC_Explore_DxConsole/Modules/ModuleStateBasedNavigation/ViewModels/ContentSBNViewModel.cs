using System.ComponentModel;
using System.Windows;
using PrismDemo.Domain;
using System.Collections.ObjectModel;
using Prism.Commands;
using ModuleInterfaces;
using VNC.Core.Mvvm;
using VNCExploreConsole.Infrastructure;
//using Microsoft.Windows.Controls;

namespace ModuleSBN
{
    public class ContentSBNViewModel : IContentSBNViewModel, INotifyPropertyChanged
    {
        private readonly IPersonService _personService;

        #region Properties

        public DelegateCommand EditPersonCommand { get; private set; }

        private ObservableCollection<Person> _People;
        public ObservableCollection<Person> People
        {
            get { return _People; }
            set
            {
                _People = value;
                OnPropertyChanged("People");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                EditPersonCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("SelectedPerson");
            }
        }

        private WindowState _windowState;
        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                _windowState = value;
                OnPropertyChanged("WindowState");
            }
        }

        public IView View
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        IView IViewModel.View { get; set; }

        #endregion //Properties

        #region Constructors

        // Pass in an IPersonService to avoid having a direct dependency
        // on Services.PersonService
        public ContentSBNViewModel(IPersonService personService)
        {
            _personService = personService;

            LoadPeople();

            EditPersonCommand = new DelegateCommand(EditPerson, CanEditPerson);
        }

        #endregion //Constructors

        #region Commands

        private void EditPerson()
        {
            WindowState = System.Windows.WindowState.Normal;
        }

        private bool CanEditPerson()
        {
            return SelectedPerson != null;
        }

        #endregion //Commands

        #region Methods

        private void LoadPeople()
        {
            IsBusy = true;

            _personService.GetPeopleAsync((sender, result) =>
            {
                People = new ObservableCollection<Person>(result.Object);
                IsBusy = false;
            });
        }

        #endregion //Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged
    }
}
