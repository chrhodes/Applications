using Prism.Commands;
using Prism.Events;
using VNCExploreConsole.Infrastructure;
using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModulePeople
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        IEventAggregator _eventAggregator;
        IPersonRepository _personRepository;

        #region "Constructors, Initialization, and Load"

        public PersonViewModel(IPerson view)
            : base(view)
        {
            CreatePerson();

            // Use this form if do not need/want to pass parameters to methods
            //SaveCommand = new DelegateCommand(Save, CanSave);

            // Use this form to pass nullable command parameter.  Use object or other nullable type.
            SaveCommand = new DelegateCommand<PrismDemo.Domain.Person>(Save, CanSave);

            // Register the SaveCommand with the CompositeCommand declared in GlobalCommands.

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        // Need to pass in EventAggregator

        public PersonViewModel(IPerson view, IEventAggregator eventAggregator)
            : base(view)
        {
            _eventAggregator = eventAggregator;

            CreatePerson();

            // Use this form if do not need/want to pass parameters to methods
            //SaveCommand = new DelegateCommand(Save, CanSave);

            // Use this form to pass nullable command parameter.  Use object or other nullable type.
            SaveCommand = new DelegateCommand<PrismDemo.Domain.Person>(Save, CanSave);

            // Register the SaveCommand with the CompositeCommand declared in GlobalCommands.

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        public PersonViewModel(IPerson view, IEventAggregator eventAggregator, IPersonRepository personRepository)
            : base(view)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;

            // Use this form if do not need/want to pass parameters to methods
            //SaveCommand = new DelegateCommand(Save, CanSave);

            // Use this form to pass nullable command parameter.  Use object or other nullable type.
            SaveCommand = new DelegateCommand<PrismDemo.Domain.Person>(Save, CanSave);

            // Register the SaveCommand with the CompositeCommand declared in GlobalCommands.

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        #endregion

        #region Enums, Fields, Properties

        private PrismDemo.Domain.Person _person;
        public PrismDemo.Domain.Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                _person.PropertyChanged += Person_PropertyChanged;
                OnPropertyChanged("Person");
            }
        }

        //public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand<PrismDemo.Domain.Person> SaveCommand { get; set; }

        public string ViewName
        {
            get
            {
                return string.Format("{0}, {1}", Person.LastName, Person.FirstName);
            }
        }

        #endregion

        #region Public Methods

        private void CreatePerson()
        {
            Person = new PrismDemo.Domain.Person()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new PrismDemo.Domain.Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0 // This is an invalid age.  Must correct before saving.
            };
        }

        #endregion

        #region Private Methods

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void Save()
        {
            // This is doing a local save.

            //Person.LastUpdated = DateTime.Now;

            // This uses the repository

            int count = _personRepository.SavePerson(Person);
            //MessageBox.Show(count.ToString());

            // Publish when person saved.
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}", 
                Person.LastName, Person.FirstName, count));
        }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }

        private void Save(PrismDemo.Domain.Person value)
        {
            if (value is null)
            {
                // This is doing a local save.
                //Person.LastUpdated = DateTime.Now;
                // This uses the repository

                int count = _personRepository.SavePerson(Person);
                //MessageBox.Show(count.ToString());

                // Publish when person saved.
                _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}",
                    Person.LastName, Person.FirstName, count));
            }
            else
            {
                // This is doing a local save.
                //Person.LastUpdated = DateTime.Now.AddYears(value.Age);

                // This uses the repository

                int count = _personRepository.SavePerson(Person);
                //MessageBox.Show(count.ToString());

                // Publish when person saved.
                _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}",
                    Person.LastName, Person.FirstName, count));
            }
        }

        private bool CanSave(PrismDemo.Domain.Person value)
        {
            if (Person != null)
            {
                return Person.Error == null;
            }

            return false;
        }

        #endregion
    }
}
