using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Prism.Events;

using PrismAppEF5.DomainServices;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismAppEF5.Presentation.ViewModels
{
    public class NavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public NavigationViewModel(
                ICatLookupDataService catLookupDataService,
                IDogLookupDataService dogLookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _CatLookupDataService = catLookupDataService;
            _DogLookupDataService = dogLookupDataService;

            Cats = new ObservableCollection<NavigationItemViewModel>();
            Dogs = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private ICatLookupDataService _CatLookupDataService;
        private IDogLookupDataService _DogLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Cats { get; }
        public ObservableCollection<NavigationItemViewModel> Dogs { get; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(CatDetailViewModel):
                    AfterDetailSaved(Cats, args);
                    break;

                case nameof(DogDetailViewModel):
                    AfterDetailSaved(Dogs, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(CatDetailViewModel):
                    AfterDetailDeleted(Cats, args);
                    break;

                case nameof(DogDetailViewModel):
                    AfterDetailDeleted(Dogs, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(NavigationViewModel) Enter", Common.LOG_APPNAME);

            var lookupCats = await _CatLookupDataService.GetCatLookupAsync();
            Cats.Clear();

            foreach (var item in lookupCats)
            {
                Cats.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(CatDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            var lookupDogs = await _DogLookupDataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookupDogs)
            {
                Dogs.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DogDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            Log.VIEWMODEL("(NavigationViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


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
