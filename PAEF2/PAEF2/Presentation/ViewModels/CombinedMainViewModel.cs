using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF2.Presentation.ViewModels
{
    public class CombinedMainViewModel : EventViewModelBase, ICombinedMainViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CombinedMainViewModel(
            ICombinedNavigationViewModel navigationViewModel,
            //Func<ICatDetailViewModel> catDetailViewModelCreator,
            Func<ICarDetailViewModel> CarDetailViewModelCreator,
            Func<IDoorDetailViewModel> DoorDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            NavigationViewModel = navigationViewModel;
            //_CatDetailViewModelCreator = catDetailViewModelCreator;
            _CarDetailViewModelCreator = CarDetailViewModelCreator;
            _DoorDetailViewModelCreator = DoorDetailViewModelCreator;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            DetailViewModels = new ObservableCollection<IDetailViewModel>();

            EventAggregator.GetEvent<OpenDetailViewEvent>()
                .Subscribe(OpenDetailView);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            EventAggregator.GetEvent<AfterDetailClosedEvent>()
                .Subscribe(AfterDetailClosed);

            CreateNewDetailCommand = new DelegateCommand<Type>(
                CreateNewDetailExecute);

            OpenSingleDetailViewCommand = new DelegateCommand<Type>(
                OpenSingleDetailExecute);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private Func<ICarDetailViewModel> _CarDetailViewModelCreator;
        private Func<IDoorDetailViewModel> _DoorDetailViewModelCreator;

        private IDetailViewModel _selectedDetailViewModel;

        public ICommand CreateNewDetailCommand { get; private set; }

        public ICommand OpenSingleDetailViewCommand { get; private set; }

        // N.B. This is public so View.Xaml can bind to it.
        public ICombinedNavigationViewModel NavigationViewModel { get; private set; }

        public ObservableCollection<IDetailViewModel> DetailViewModels { get; private set; }

        private int _nextNewItemId = 0;

        public IDetailViewModel SelectedDetailViewModel
        {
            get
            {
                return _selectedDetailViewModel;
            }
            set
            {
                _selectedDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Event Handlers

        void OpenSingleDetailExecute(Type viewModelType)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            OpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = -1,
                    ViewModelName = viewModelType.Name
                });

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void CreateNewDetailExecute(Type viewModelType)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            OpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = _nextNewItemId--,  // Ids in DB > 0.  Can now create multiple new items
                    ViewModelName = viewModelType.Name
                });

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void OpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"(CarMainViewModel) Enter Id:({args.Id}(", Common.LOG_CATEGORY);

            var detailViewModel = DetailViewModels
                    .SingleOrDefault(vm => vm.Id == args.Id
                    && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                switch (args.ViewModelName)
                {

                    // case nameof(CatDetailViewModel):
                    // detailViewModel = (IDetailViewModel)_CatDetailViewModelCreator();
                    // break;

                    case nameof(CarDetailViewModel):
                        detailViewModel = (IDetailViewModel)_CarDetailViewModelCreator();
                        break;

                    //case nameof(MeetingDetailViewModel):
                    //    detailViewModel = _meetingDetailViewModelCreator();
                    //    break;

                    case nameof(DoorDetailViewModel):
                        detailViewModel = _DoorDetailViewModelCreator();
                        break;

                    // This should not happen anymore withe TYPEEvent
                    default:
                        return;
                }

                // Verify item still exists (may have been deleted)

                try
                {
                    await detailViewModel.LoadAsync(args.Id);
                }
                catch (Exception ex)
                {
                    var message = $"Cannot load the entity ({ex}) It may have been deleted by another user";

                    DialogService.Show("NotificationDialog", new DialogParameters($"message={message}"), r =>
                    {
                    });

                    await NavigationViewModel.LoadAsync();
                    return;
                }

                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;

            Log.VIEWMODEL("(CarMainViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        void AfterDetailClosed(AfterDetailClosedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            var detailViewModel = DetailViewModels
                .SingleOrDefault(vm => vm.Id == id
                && vm.GetType().Name == viewModelName);

            if (detailViewModel != null)
            {
                DetailViewModels.Remove(detailViewModel);
            }

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("CombinedMainViewModel) Enter", Common.LOG_CATEGORY);

            await NavigationViewModel.LoadAsync();

            Log.VIEWMODEL("CombinedMainViewModel) Exit", Common.LOG_CATEGORY, startTicks);
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
