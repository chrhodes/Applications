using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using PAI1.Domain;
using PAI1.DomainServices;
using PAI1.Presentation.ModelWrappers;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAI1.Presentation.ViewModels
{
    public class DogDetailViewModel : DetailViewModelBase, IDogDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public DogDetailViewModel(
                IDogDataService DogDataService,
                IFoodLookupDataService FoodLookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _DogDataService = DogDataService;
            _FoodLookupDataService = FoodLookupDataService;

            eventAggregator.GetEvent<AfterCollectionSavedEvent>()
                .Subscribe(AfterCollectionSaved);

            AddPhoneNumberCommand = new DelegateCommand(
                OnAddPhoneNumberExecute);

            RemovePhoneNumberCommand = new DelegateCommand(
                OnRemovePhoneNumberExecute, OnRemovePhoneNumberCanExecute);

            Foods = new ObservableCollection<LookupItem>();
            PhoneNumbers = new ObservableCollection<DogPhoneNumberWrapper>();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums

        #endregion

        #region Structures

        #endregion

        #region Fields and Properties

        private IDogDataService _DogDataService;
        private IFoodLookupDataService _FoodLookupDataService;

        public ICommand AddPhoneNumberCommand { get; }
        public ICommand RemovePhoneNumberCommand { get; }

        private DogPhoneNumberWrapper _selectedPhoneNumber;

        public ObservableCollection<LookupItem> Foods { get; }
        public ObservableCollection<DogPhoneNumberWrapper> PhoneNumbers { get; }

        // Maybe call this Dogw
        // or 
        private DogWrapper _Dog;

        public DogWrapper Dog
        {
            get { return _Dog; }
            private set
            {
                _Dog = value;
                OnPropertyChanged();
            }
        }

        public DogPhoneNumberWrapper SelectedPhoneNumber
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

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            await LoadAsync(args.Id);

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(DogDetailViewModel) Enter", Common.LOG_APPNAME);

            if (args.ViewModelName == nameof(FoodDetailViewModel))
            {
                await LoadFoodsLookupAsync();
            }

            Log.EVENT_HANDLER("(DogDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL($"(DogDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            var item = id > 0
                ? await _DogDataService.FindByIdAsync(id)
                : CreateNewDog();

            Id = item.Id;

            InitializeDog(item);

            InitializeDogPhoneNumbers(item.PhoneNumbers);

            await LoadFoodsLookupAsync();

            Log.VIEWMODEL("(DogDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Protected Methods

        protected override bool OnDeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        protected override async void OnDeleteExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(DogDetailViewModel) Enter Id:({Dog.Id})", Common.LOG_APPNAME);

            var result = MessageDialogService.ShowOkCancelDialog(
                "Do you really want to delete the Dog?", "Question");

            if (result == MessageDialogResult.OK)
            {
                _DogDataService.Remove(Dog.Model);

                await _DogDataService.UpdateAsync();

                PublishAfterDetailDeletedEvent(Dog.Id);
            }

            Log.VIEWMODEL("(DogDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Dog is valid or has changes
            // This enables and disables the button

            var result = Dog != null
                && !Dog.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(DogDetailViewModel) Enter Id:({Dog.Id})", Common.LOG_APPNAME);

            await _DogDataService.UpdateAsync();

            //await SaveWithOptimisticConcurrencyAsync(_DogDataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _DogDataService.HasChanges();
            //      Id = Dog.Id;
            //      RaiseDetailSavedEvent(Dog.Id, $"{Dog.FieldString}");
            //  });

            HasChanges = false;
            Id = Dog.Id;

            PublishAfterDetailSavedEvent(Dog.Id, Dog.FieldString);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void OnAddPhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            var newNumber = new DogPhoneNumberWrapper(new DogPhoneNumber());
            newNumber.PropertyChanged += DogPhoneNumberWrapper_PropertyChanged;
            PhoneNumbers.Add(newNumber);
            Dog.Model.PhoneNumbers.Add(newNumber.Model);
            newNumber.Number = ""; // Trigger validation :-)

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void OnRemovePhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            SelectedPhoneNumber.PropertyChanged -= DogPhoneNumberWrapper_PropertyChanged;
            //_friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            PhoneNumbers.Remove(SelectedPhoneNumber);
            SelectedPhoneNumber = null;
            HasChanges = _DogDataService.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private bool OnRemovePhoneNumberCanExecute()
        {
            return SelectedPhoneNumber != null;
        }

        #endregion

        #region Private Methods

        private Domain.Dog CreateNewDog()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var item = new Domain.Dog();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;
            _DogDataService.Add(item);

            // TODO(crhodes)
            // Need to figure out how to handle creating new.
            // This tries to push all the way to the database which complains because
            // Haven't set Required Fields (e.g. FieldString)

            // This was our attempt to use our DataService later - but that creates a context and tries to add item which
            // throws exception

            //_dataService.Insert(item);

            // This is what was in Claudius Code (NB>  Add does not call Save Changes in his code
            //_friendRepository.Add(friend);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);

            return item;
        }

        private void InitializeDog(Dog item)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            Dog = new DogWrapper(item);

            Dog.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _DogDataService.HasChanges();
                }

                if (e.PropertyName == nameof(Dog.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

                if (e.PropertyName == nameof(Dog.FieldString))
                {
                    SetTitle();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            // Little trick to trigger the validation when creating new entries
            if (Dog.Id == 0)
            {
                Dog.FieldString = "";
            }

            SetTitle();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeDogPhoneNumbers(ICollection<DogPhoneNumber> phoneNumbers)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            foreach (var wrapper in PhoneNumbers)
            {
                wrapper.PropertyChanged -= DogPhoneNumberWrapper_PropertyChanged;
            }

            PhoneNumbers.Clear();

            foreach (var phoneNumber in phoneNumbers)
            {
                var wrapper = new DogPhoneNumberWrapper(phoneNumber);
                PhoneNumbers.Add(wrapper);
                wrapper.PropertyChanged += DogPhoneNumberWrapper_PropertyChanged;
            }

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void DogPhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            if (!HasChanges)
            {
                HasChanges = _DogDataService.HasChanges();
            }
            if (e.PropertyName == nameof(DogPhoneNumberWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async Task LoadFoodsLookupAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(DogDetailViewModel) Enter", Common.LOG_APPNAME);

            Foods.Clear();

            //ProgrammingLanguages.Add(new NullLookupItem());
            Foods.Add(new NullLookupItem { DisplayMember = " - " });

            var lookup = await _FoodLookupDataService
                                .GetFoodLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Foods.Add(lookupItem);
            }

            Log.VIEWMODEL("(DogDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{Dog.FieldString}";
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
