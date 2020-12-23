using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Prism.Events;

using PrismAppEF1.DomainServices;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismAppEF1.Presentation.ViewModels
{
    public class BirdNavigationViewModel : EventViewModelBase, IBirdNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public BirdNavigationViewModel(
                IBirdLookupDataService BirdLookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _BirdLookupDataService = BirdLookupDataService;

            Birds = new ObservableCollection<NavigationItemViewModel>();

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

        private IBirdLookupDataService _BirdLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Birds { get; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(BirdDetailViewModel):
                    AfterDetailSaved(Birds, args);
                    break;

                default:
                    return;
                    //throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(BirdDetailViewModel):
                    AfterDetailDeleted(Birds, args);
                    break;

                default:
                    return;
                    //throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(BirdNavigationViewModel) Enter", Common.LOG_APPNAME);

            var lookupBirds = await _BirdLookupDataService.GetBirdLookupAsync();

            Birds.Clear();

            foreach (var item in lookupBirds)
            {
                Birds.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(BirdDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            Log.VIEWMODEL("(BirdNavigationViewModel) Exit", Common.LOG_APPNAME, startTicks);
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
