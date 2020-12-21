using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using PAI1.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAI1.Presentation.ViewModels
{
    public class CombinedNavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CombinedNavigationViewModel(
                IDogLookupDataService DogLookupDataService,
                //I$customCatLookupDataService catLookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _DogLookupDataService = DogLookupDataService;
            //_catLookupDataService = catLookupDataService

            Dogs = new ObservableCollection<NavigationItemViewModel>();
            //Cats = new ObservableCollection<NavigationItemViewModel>();

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

        private IDogLookupDataService _DogLookupDataService;
        //private ICatLookupDataService _CatLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Dogs { get; }
        //public ObservableCollection<NavigationItemViewModel> Cats { get; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailSaved(Dogs, args);
                    break;

                // case nameof(Dog2DetailViewModel):
                // AfterDetailSaved(Dog2s, args);
                // break;

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
                case nameof(DogDetailViewModel):
                    AfterDetailDeleted(Dogs, args);
                    break;

                // case nameof(Dog2DetailViewModel):
                // AfterDetailDeleted(Dog2s, args);
                // break;

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

            var lookupDogs = await _DogLookupDataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookupDogs)
            {
                Dogs.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DogDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            // var lookupDog2s = await _Dog2LookupDataService.GetDog2LookupAsync();
            // Dog2s.Clear();

            // foreach (var item in lookupDog2s)
            // {
            // Dog2s.Add(
            // new NavigationItemViewModel(item.Id, item.DisplayMember,
            // nameof(Dog2DetailViewModel),
            // EventAggregator, MessageDialogService));
            // }

            //TODO(crhodes)
            // Load more TYPEs as needed here

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
