using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using PAEF2.Domain;
using PAEF2.DomainServices;
using PAEF2.Presentation.ModelWrappers;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF2.Presentation.ViewModels
{
    public class CarDetailViewModel : DetailViewModelBase, ICarDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public CarDetailViewModel(
            ICarDataService CarDataService,
            IDoorLookupDataService DoorLookupDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _CarDataService = CarDataService;
            _DoorLookupDataService = DoorLookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            EventAggregator.GetEvent<AfterCollectionSavedEvent>()
                .Subscribe(AfterCollectionSaved);

            AddPhoneNumberCommand = new DelegateCommand(
                AddPhoneNumberExecute);

            RemovePhoneNumberCommand = new DelegateCommand(
                RemovePhoneNumberExecute, RemovePhoneNumberCanExecute);

            Doors = new ObservableCollection<LookupItem>();
            PhoneNumbers = new ObservableCollection<CarPhoneNumberWrapper>();

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)

        #endregion

        #region Structures (none)

        #endregion

        #region Fields and Properties

        private ICarDataService _CarDataService;
        private IDoorLookupDataService _DoorLookupDataService;

        public ICommand AddPhoneNumberCommand { get; private set; }
        public ICommand RemovePhoneNumberCommand { get; private set; }

        private CarPhoneNumberWrapper _selectedPhoneNumber;

        public ObservableCollection<LookupItem> Doors { get; private set; }
        public ObservableCollection<CarPhoneNumberWrapper> PhoneNumbers { get; private set; }


        private CarWrapper _Car;

        public CarWrapper Car
        {
            get { return _Car; }
            private set
            {
                _Car = value;
                OnPropertyChanged();
            }
        }

        public CarPhoneNumberWrapper SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value;
                OnPropertyChanged();
                ((DelegateCommand)RemovePhoneNumberCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        private async void OpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            await LoadAsync(args.Id);

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(CarDetailViewModel) Enter", Common.LOG_CATEGORY);

            if (args.ViewModelName == nameof(DoorDetailViewModel))
            {
                await LoadDoorsLookupAsync();
            }

            Log.EVENT_HANDLER("(CarDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL($"(CarDetailViewModel) Enter Id:({id})", Common.LOG_CATEGORY);

            var item = id > 0
                ? await _CarDataService.FindByIdAsync(id)
                : CreateNewCar();

            Id = item.Id;

            InitializeCar(item);

            InitializeCarPhoneNumbers(item.PhoneNumbers);

            await LoadDoorsLookupAsync();

            Log.VIEWMODEL("(CarDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Protected Methods

        protected override bool DeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        protected override async void DeleteExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(CarDetailViewModel) Enter Id:({Car.Id})", Common.LOG_CATEGORY);

            var message = "Do you really want to delete the Car? ?";

            var dialogParameters = new DialogParameters();
            dialogParameters.Add("message", message);
            dialogParameters.Add("title", "Approve Deletion");
            dialogParameters.Add("okcontent", "Yes");
            dialogParameters.Add("cancelcontent", "No");

            DialogService.Show("OkCancelDialog", dialogParameters, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    _CarDataService.Remove(Car.Model);

                    await _CarDataService.UpdateAsync();

                    PublishAfterDetailDeletedEvent(Car.Id);
                }
            });

            Log.VIEWMODEL("(CarDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Car is valid or has changes
            // This enables and disables the button

            var result = Car != null
                && !Car.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(CarDetailViewModel) Enter Id:({Car.Id})", Common.LOG_CATEGORY);

            await _CarDataService.UpdateAsync();

            //await SaveWithOptimisticConcurrencyAsync(_CarDataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _CarDataService.HasChanges();
            //      Id = Car.Id;
            //      RaiseDetailSavedEvent(Car.Id, $"{Car.FieldString}");
            //  });

            HasChanges = false;
            Id = Car.Id;

            PublishAfterDetailSavedEvent(Car.Id, Car.FieldString);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AddPhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            var newNumber = new CarPhoneNumberWrapper(new CarPhoneNumber());
            newNumber.PropertyChanged += CarPhoneNumberWrapper_PropertyChanged;
            PhoneNumbers.Add(newNumber);
            Car.Model.PhoneNumbers.Add(newNumber.Model);
            newNumber.Number = ""; // Trigger validation :-)

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void RemovePhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            SelectedPhoneNumber.PropertyChanged -= CarPhoneNumberWrapper_PropertyChanged;
            //_friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            PhoneNumbers.Remove(SelectedPhoneNumber);
            SelectedPhoneNumber = null;
            HasChanges = _CarDataService.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private bool RemovePhoneNumberCanExecute()
        {
            return SelectedPhoneNumber != null;
        }

        #endregion

        #region Private Methods

        private Domain.Car CreateNewCar()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            var item = new Domain.Car();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;
            _CarDataService.Add(item);

            // TODO(crhodes)
            // Need to figure out how to handle creating new.
            // This tries to push all the way to the database which complains because
            // Haven't set Required Fields (e.g. FieldString)

            // This was our attempt to use our DataService later - but that creates a context and tries to add item which
            // throws exception

            //_dataService.Insert(item);

            // This is what was in Claudius Code (NB>  Add does not call Save Changes in his code
            //_friendRepository.Add(friend);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);

            return item;
        }

        private void InitializeCar(Car item)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            Car = new CarWrapper(item);

            Car.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _CarDataService.HasChanges();
                }

                if (e.PropertyName == nameof(Car.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

                if (e.PropertyName == nameof(Car.FieldString))
                {
                    SetTitle();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            // Little trick to trigger the validation when creating new entries
            if (Car.Id == 0)
            {
                Car.FieldString = "";
            }

            SetTitle();

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeCarPhoneNumbers(ICollection<CarPhoneNumber> phoneNumbers)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            foreach (var wrapper in PhoneNumbers)
            {
                wrapper.PropertyChanged -= CarPhoneNumberWrapper_PropertyChanged;
            }

            PhoneNumbers.Clear();

            foreach (var phoneNumber in phoneNumbers)
            {
                var wrapper = new CarPhoneNumberWrapper(phoneNumber);
                PhoneNumbers.Add(wrapper);
                wrapper.PropertyChanged += CarPhoneNumberWrapper_PropertyChanged;
            }

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void CarPhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            if (!HasChanges)
            {
                HasChanges = _CarDataService.HasChanges();
            }
            if (e.PropertyName == nameof(CarPhoneNumberWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async Task LoadDoorsLookupAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(CarDetailViewModel) Enter", Common.LOG_CATEGORY);

            Doors.Clear();

            //ProgrammingLanguages.Add(new NullLookupItem());
            Doors.Add(new NullLookupItem { DisplayMember = " - " });

            var lookup = await _DoorLookupDataService
                                .GetDoorLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Doors.Add(lookupItem);
            }

            Log.VIEWMODEL("(CarDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{Car.FieldString}";
        }

        #endregion

        #region IInstanceCount

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
