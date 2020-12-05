using System.Threading.Tasks;

using PrismApp1.Core.Events;
//using PrismApp1.DomainServices;
using Prism.Events;

using VNC.Core.Mvvm;
using System;
using System.Windows.Input;
using Prism.Commands;

namespace PrismApp1.Presentation.Dog.ViewModels
{
    class DogDetailViewModel : ViewModelBase, IDogDetailViewModel
    {
        private IDogDataService _dataService;
        private IEventAggregator _eventAggregator;

        public DogDetailViewModel(
                IDogDataService dataService,
                IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenDogDetailViewEvent>()
                .Subscribe(OnOpenDogDetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);
        }

        private void OnOpenDogDetailView(AfterDogSavedEventArgs obj)
        {
            throw new NotImplementedException();
        }

        private async void OnOpenDogDetailView(int typeId)
        {
            await LoadAsync(typeId);
        }

        public async Task LoadAsync(int id)
        {
            Type = await _dataService.FindByIdAsync(id);
        }

        private PrismApp1.Domain.Dog _type;

        public PrismApp1.Domain.Dog Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        async void OnSaveExecute()
        {
            await _dataService.UpdateAsync(Type);

            // Tell the Customer that we have updated something
            _eventAggregator.GetEvent<AfterDogSavedEvent>()
                .Publish(new AfterDogSavedEventArgs
                {
                    Id = Type.Id,
                    DisplayMember = Type.FieldString
                    //DisplayMember = $"{Type.FieldString} {Customer.LastName}"
                });

        }

        bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }
    }
}
