using System.Collections.ObjectModel;
using System.Threading.Tasks;

using PrismApp1.Core.Events;
using PrismApp1.DomainServices;

using Prism.Events;

using VNC.Core.Domain;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Dog.ViewModels
{
    public class DogViewModel : ViewModelBase, IDogViewModel, IViewModel
    {
        private IDogLookupDataService _dataService;
        private IEventAggregator _eventAggregator;

        public DogViewModel(
                IDogLookupDataService DogLookupDataService,
                IEventAggregator eventAggregator)
        {
            _dataService = DogLookupDataService;
            _eventAggregator = eventAggregator;
            Dogs = new ObservableCollection<NavigationItemViewModel>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _dataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookup)
            {
                Dogs.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Dogs { get; }

        public IView View
        {
            get;
            set;
        }

        NavigationItemViewModel _selectedDog;

        public NavigationItemViewModel SelectedDog
        {
            get { return _selectedDog; }
            set
            {
                _selectedDog = value;
                OnPropertyChanged();

                if (_selectedDog != null)
                {
                    _eventAggregator.GetEvent<OpenDogDetailViewEvent>()
                        .Publish(_selectedDog.Id);
                }
            }
        }
    }
}
