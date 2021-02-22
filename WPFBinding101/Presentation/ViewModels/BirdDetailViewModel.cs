using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using WPFBinding101.Domain;
using WPFBinding101.DomainServices;
using WPFBinding101.Presentation.ModelWrappers;

namespace WPFBinding101.Presentation.ViewModels
{
    public class BirdDetailViewModel : DetailViewModelBase, IBirdDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public BirdDetailViewModel(
            IBirdDataService BirdDataService,
            ISeedLookupDataService SeedLookupDataService,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _BirdDataService = BirdDataService;
            _SeedLookupDataService = SeedLookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            EventAggregator.GetEvent<AfterCollectionSavedEvent>()
                .Subscribe(AfterCollectionSaved);

            AddPhoneNumberCommand = new DelegateCommand(
                AddPhoneNumberExecute);

            RemovePhoneNumberCommand = new DelegateCommand(
                RemovePhoneNumberExecute, RemovePhoneNumberCanExecute);

            Seeds = new ObservableCollection<LookupItem>();
            PhoneNumbers = new ObservableCollection<BirdPhoneNumberWrapper>();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums

        #endregion

        #region Structures

        #endregion

        #region Fields and Properties

        private IBirdDataService _BirdDataService;
        private ISeedLookupDataService _SeedLookupDataService;

        public ICommand AddPhoneNumberCommand { get; private set; }
        public ICommand RemovePhoneNumberCommand { get; private set; }

        private BirdPhoneNumberWrapper _selectedPhoneNumber;

        public ObservableCollection<LookupItem> Seeds { get; private set; }
        public ObservableCollection<BirdPhoneNumberWrapper> PhoneNumbers { get; private set; }


        private BirdWrapper _Bird;

        public BirdWrapper Bird
        {
            get { return _Bird; }
            private set
            {
                _Bird = value;
                OnPropertyChanged();
            }
        }

        public BirdPhoneNumberWrapper SelectedPhoneNumber
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
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            await LoadAsync(args.Id);

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(BirdDetailViewModel) Enter", Common.LOG_APPNAME);

            if (args.ViewModelName == nameof(SeedDetailViewModel))
            {
                await LoadSeedsLookupAsync();
            }

            Log.EVENT_HANDLER("(BirdDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL($"(BirdDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            var item = id > 0
                ? await _BirdDataService.FindByIdAsync(id)
                : CreateNewBird();

            Id = item.Id;

            InitializeBird(item);

            InitializeBirdPhoneNumbers(item.PhoneNumbers);

            await LoadSeedsLookupAsync();

            Log.VIEWMODEL("(BirdDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
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
            Int64 startTicks = Log.VIEWMODEL($"(BirdDetailViewModel) Enter Id:({Bird.Id})", Common.LOG_APPNAME);

            var result = MessageDialogService.ShowOkCancelDialog(
                "Do you really want to delete the Bird?", "Question");

            if (result == MessageDialogResult.OK)
            {
                _BirdDataService.Remove(Bird.Model);

                await _BirdDataService.UpdateAsync();

                PublishAfterDetailDeletedEvent(Bird.Id);
            }

            Log.VIEWMODEL("(BirdDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Bird is valid or has changes
            // This enables and disables the button

            var result = Bird != null
                && !Bird.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(BirdDetailViewModel) Enter Id:({Bird.Id})", Common.LOG_APPNAME);

            await _BirdDataService.UpdateAsync();

            //await SaveWithOptimisticConcurrencyAsync(_BirdDataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _BirdDataService.HasChanges();
            //      Id = Bird.Id;
            //      RaiseDetailSavedEvent(Bird.Id, $"{Bird.FieldString}");
            //  });

            HasChanges = false;
            Id = Bird.Id;

            PublishAfterDetailSavedEvent(Bird.Id, Bird.FieldString);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AddPhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            var newNumber = new BirdPhoneNumberWrapper(new BirdPhoneNumber());
            newNumber.PropertyChanged += BirdPhoneNumberWrapper_PropertyChanged;
            PhoneNumbers.Add(newNumber);
            Bird.Model.PhoneNumbers.Add(newNumber.Model);
            newNumber.Number = ""; // Trigger validation :-)

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void RemovePhoneNumberExecute()
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            SelectedPhoneNumber.PropertyChanged -= BirdPhoneNumberWrapper_PropertyChanged;
            //_friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            PhoneNumbers.Remove(SelectedPhoneNumber);
            SelectedPhoneNumber = null;
            HasChanges = _BirdDataService.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private bool RemovePhoneNumberCanExecute()
        {
            return SelectedPhoneNumber != null;
        }

        #endregion

        #region Private Methods

        private Domain.Bird CreateNewBird()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var item = new Domain.Bird();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;
            _BirdDataService.Add(item);

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

        private void InitializeBird(Bird item)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            Bird = new BirdWrapper(item);

            Bird.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _BirdDataService.HasChanges();
                }

                if (e.PropertyName == nameof(Bird.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

                if (e.PropertyName == nameof(Bird.FieldString))
                {
                    SetTitle();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            // Little trick to trigger the validation when creating new entries
            if (Bird.Id == 0)
            {
                Bird.FieldString = "";
            }

            SetTitle();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeBirdPhoneNumbers(ICollection<BirdPhoneNumber> phoneNumbers)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            foreach (var wrapper in PhoneNumbers)
            {
                wrapper.PropertyChanged -= BirdPhoneNumberWrapper_PropertyChanged;
            }

            PhoneNumbers.Clear();

            foreach (var phoneNumber in phoneNumbers)
            {
                var wrapper = new BirdPhoneNumberWrapper(phoneNumber);
                PhoneNumbers.Add(wrapper);
                wrapper.PropertyChanged += BirdPhoneNumberWrapper_PropertyChanged;
            }

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void BirdPhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            if (!HasChanges)
            {
                HasChanges = _BirdDataService.HasChanges();
            }
            if (e.PropertyName == nameof(BirdPhoneNumberWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async Task LoadSeedsLookupAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(BirdDetailViewModel) Enter", Common.LOG_APPNAME);

            Seeds.Clear();

            //ProgrammingLanguages.Add(new NullLookupItem());
            Seeds.Add(new NullLookupItem { DisplayMember = " - " });

            var lookup = await _SeedLookupDataService
                                .GetSeedLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Seeds.Add(lookupItem);
            }

            Log.VIEWMODEL("(BirdDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{Bird.FieldString}";
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
