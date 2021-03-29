using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Prism.Events;

using .DomainServices;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace .Presentation.ViewModels
{
    public class CombinedNavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CombinedNavigationViewModel(
                ILookupDataService LookupDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _LookupDataService = LookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            s = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private ILookupDataService _LookupDataService;

        public ObservableCollection<NavigationItemViewModel> s { get; private set;}

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(DetailViewModel):
                    AfterDetailSaved(s, args);
                    break;

                // case nameof(2DetailViewModel):
                    // AfterDetailSaved(2s, args);
                    // break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(DetailViewModel):
                    AfterDetailDeleted(s, args);
                    break;

                // case nameof(2DetailViewModel):
                    // AfterDetailDeleted(2s, args);
                    // break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(NavigationViewModel) Enter", Common.LOG_CATEGORY);

            var lookups = await _LookupDataService.GetLookupAsync();
            s.Clear();

            foreach (var item in lookups)
            {
                s.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            // var lookup2s = await _2LookupDataService.Get2LookupAsync();
            // 2s.Clear();

            // foreach (var item in lookup2s)
            // {
                // 2s.Add(
                    // new NavigationItemViewModel(item.Id, item.DisplayMember,
                    // nameof(2DetailViewModel),
                    // EventAggregator, MessageDialogService));
            // }

            //TODO(crhodes)
            // Load more TYPEs as needed here

            Log.VIEWMODEL("(NavigationViewModel) Exit", Common.LOG_CATEGORY, startTicks);
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
