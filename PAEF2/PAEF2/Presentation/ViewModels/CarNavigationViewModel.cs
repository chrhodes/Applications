using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using PAEF2.DomainServices;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF2.Presentation.ViewModels
{
    public class CarNavigationViewModel : EventViewModelBase, ICarNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CarNavigationViewModel(
            ICarLookupDataService CarLookupDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _CarLookupDataService = CarLookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            Cars = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private ICarLookupDataService _CarLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Cars { get; private set; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(CarDetailViewModel):
                    AfterDetailSaved(Cars, args);
                    break;

                default:
                    return;
                    //throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(CarDetailViewModel):
                    AfterDetailDeleted(Cars, args);
                    break;

                default:
                    return;
                    //throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(CarNavigationViewModel) Enter", Common.LOG_CATEGORY);

            var lookupCars = await _CarLookupDataService.GetCarLookupAsync();

            Cars.Clear();

            foreach (var item in lookupCars)
            {
                Cars.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(CarDetailViewModel),
                    EventAggregator, DialogService));
            }

            Log.VIEWMODEL("(CarNavigationViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


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
