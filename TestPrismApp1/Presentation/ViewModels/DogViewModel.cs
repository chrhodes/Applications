using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Prism.Events;

using TestPrismApp1.Core.Events;
using TestPrismApp1.DomainServices;
using TestPrismApp1.Presentation.ViewModels;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Mvvm;

namespace TestPrismApp1.Presentation.ViewModels
{
    public class DogViewModel : ViewModelBase, IDogViewModel
    {
        private IDogLookupDataService _dataService;
        private IEventAggregator _eventAggregator;

        public DogViewModel(
                IDogLookupDataService DogLookupDataService,
                IEventAggregator eventAggregator)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = DogLookupDataService;
            _eventAggregator = eventAggregator;
            Dogs = new ObservableCollection<NavigationItemViewModel>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookup = await _dataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookup)
            {
                Dogs.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
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
