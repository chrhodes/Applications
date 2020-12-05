using System;
using System.Collections.ObjectModel;
using VNC.Core.Mvvm;
using ModuleInterfaces;

namespace ModulePeople
{
    public class PeopleViewModel : ViewModelBase, IPeopleViewModel
    {
        public PeopleViewModel(IPeople view)
            : base(view)
        {
            CreatePeople();
        }

        private ObservableCollection<PrismDemo.Domain.Person> _people;
        public ObservableCollection<PrismDemo.Domain.Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged("People");
            }
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<PrismDemo.Domain.Person>();
            for (int i = 0; i < 5; i++)
            {
                people.Add(new PrismDemo.Domain.Person()
                {
                    FirstName = String.Format("First {0}", i),
                    LastName = String.Format("Last {0}", i)
                });
            }

            People = people;
        }
    }
}
