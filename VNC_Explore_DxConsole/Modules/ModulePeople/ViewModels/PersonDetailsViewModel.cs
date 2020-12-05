using VNC.Core.Mvvm;
using ModuleInterfaces;
using PrismDemo.Domain;

namespace ModulePeople
{
    public class PersonDetailsViewModel : ViewModelBase, IPersonDetailsViewModel
    {
        public PersonDetailsViewModel() { }

        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
            set
            {
                _SelectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        PrismDemo.Domain.Person IPersonDetailsViewModel.SelectedPerson { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
