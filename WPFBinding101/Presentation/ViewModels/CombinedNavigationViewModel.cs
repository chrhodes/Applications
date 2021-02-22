using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using WPFBinding101.DomainServices;

namespace WPFBinding101.Presentation.ViewModels
{
    public class CombinedNavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CombinedNavigationViewModel(
                IBirdLookupDataService BirdLookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _BirdLookupDataService = BirdLookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            Birds = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private IBirdLookupDataService _BirdLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Birds { get; private set; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(BirdDetailViewModel):
                    AfterDetailSaved(Birds, args);
                    break;

                // case nameof(Bird2DetailViewModel):
                // AfterDetailSaved(Bird2s, args);
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
                case nameof(BirdDetailViewModel):
                    AfterDetailDeleted(Birds, args);
                    break;

                // case nameof(Bird2DetailViewModel):
                // AfterDetailDeleted(Bird2s, args);
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

            var lookupBirds = await _BirdLookupDataService.GetBirdLookupAsync();
            Birds.Clear();

            foreach (var item in lookupBirds)
            {
                Birds.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(BirdDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            // var lookupBird2s = await _Bird2LookupDataService.GetBird2LookupAsync();
            // Bird2s.Clear();

            // foreach (var item in lookupBird2s)
            // {
            // Bird2s.Add(
            // new NavigationItemViewModel(item.Id, item.DisplayMember,
            // nameof(Bird2DetailViewModel),
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
