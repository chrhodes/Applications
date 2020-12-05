using System;
using VNC.Core.Mvvm;
//using Business;
//using Microsoft.Practices.Prism.Commands;
using Prism.Commands;
using Prism.Events;
using System.Windows;
using ModuleInterfaces;

namespace ModulePeopleDC
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        #region "Constructors, Initialization, and Load"

        public PersonViewModel(IPerson view)
            : base(view)
        {
            CreatePerson();

            // Use this form if do not need/want to pass parameters to methods

            //SaveCommand = new DelegateCommand(Save, CanSave);

            // Use this form to pass nullable command parameter.  Use object or other nullable type.

            SaveCommand = new DelegateCommand<PrismDemo.Domain.Person>(Save, CanSave);
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
                // Hook in event handler to force (re)check of CanSave
                _person.PropertyChanged += Person_PropertyChanged;
                OnPropertyChanged("Person");
            }
        }

        #endregion

        #region Public Methods

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

        private void CreatePerson()
        {
            Person = new PrismDemo.Domain.Person()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Force calling of CanSave on SaveCommand delegate
            SaveCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region DelegateCommand taking no parameters

        //public DelegateCommand SaveCommand { get; set; }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }

        private void Save()
        {
            // This is doing a local save.

            Person.LastUpdated = DateTime.Now;

            //// This uses the repository

            //int count = _personRepository.SavePerson(Person);
            ////MessageBox.Show(count.ToString());

            //// Publish when person saved.
            //_eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}", 
            //    Person.LastName, Person.FirstName, count));
        }

        #endregion

        #region DelegateCommand taking a <Person>

        public DelegateCommand<PrismDemo.Domain.Person> SaveCommand { get; set; }
        IView IViewModel.View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool CanSave(PrismDemo.Domain.Person value)
        {
            if (Person != null)
            {
                return Person.Error == null;
            }

            return false;
        }

        private void Save(PrismDemo.Domain.Person value)
        {
            if (value is null)
            {
                // This is doing a local save.
                Person.LastUpdated = DateTime.Now;
                // This uses the repository

                //int count = _personRepository.SavePerson(Person);
                ////MessageBox.Show(count.ToString());

                //// Publish when person saved.
                //_eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}",
                //    Person.LastName, Person.FirstName, count));
            }
            else
            {
                // This is doing a local save.
                Person.LastUpdated = DateTime.Now.AddYears(value.Age);

                // This uses the repository

                //int count = _personRepository.SavePerson(Person);
                ////MessageBox.Show(count.ToString());

                //// Publish when person saved.
                //_eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}  Count:{2}",
                //    Person.LastName, Person.FirstName, count));
            }
        }

        #endregion
    }
}
