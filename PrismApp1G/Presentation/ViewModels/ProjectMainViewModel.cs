using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using PrismApp1.Core.Events;
using PrismApp1.DomainServices;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismApp1.Presentation.ViewModels
{
    public class ProjectMainViewModel : ViewModelBase, IProjectMainViewModel
    {
        private IProjectLookupDataService _dataService;
        private IEventAggregator _eventAggregator;

        private Func<IProjectDetailViewModel> _ProjectDetailViewModelCreator;

        private IDetailViewModel _selectedDetailViewModel;
        private IMessageDialogService _messageDialogService;

        public ICommand CreateNewDetailCommand { get; }

        public ICommand OpenSingleDetailViewCommand { get; }

        // N.B. This is public so View.Xaml can bind to it.
        public INavigationViewModel NavigationViewModel { get; }

        public ProjectMainViewModel(
            INavigationViewModel navigationViewModel,
            Func<IProjectDetailViewModel> ProjectDetailViewModelCreator,
            IProjectLookupDataService ProjectLookupDataService,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = ProjectLookupDataService;
            _eventAggregator = eventAggregator;
            _ProjectDetailViewModelCreator = ProjectDetailViewModelCreator;
            _messageDialogService = messageDialogService;

            DetailViewModels = new ObservableCollection<IDetailViewModel>();

            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                .Subscribe(OnOpenDetailView);

            _eventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            _eventAggregator.GetEvent<AfterDetailClosedEvent>()
                .Subscribe(AfterDetailClosed);

            CreateNewDetailCommand = new DelegateCommand<Type>(
                OnCreateNewDetailExecute);

            OpenSingleDetailViewCommand = new DelegateCommand<Type>(
                OnOpenSingleDetailExecute);

            NavigationViewModel = navigationViewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ObservableCollection<IDetailViewModel> DetailViewModels { get; }

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

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await NavigationViewModel.LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ObservableCollection<NavigationItemViewModel> Projects { get; }

        public IView View
        {
            get;
            set;
        }

        NavigationItemViewModel _selectedProject;

        public NavigationItemViewModel SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                OnPropertyChanged();

                if (_selectedProject != null)
                {
                    _eventAggregator.GetEvent<OpenProjectDetailViewEvent>()
                        .Publish(_selectedProject.Id);
                }
            }
        }

        private int _nextNewItemId = 0;

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            OnOpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = _nextNewItemId--,  // Ids in DB > 0.  Can now create multiple new items
                    ViewModelName = viewModelType.Name
                });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var detailViewModel = DetailViewModels
                    .SingleOrDefault(vm => vm.Id == args.Id
                    && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                switch (args.ViewModelName)
                {
                    case nameof(ProjectDetailViewModel):
                        detailViewModel = (IDetailViewModel)_ProjectDetailViewModelCreator();
                        break;

                        //case nameof(MeetingDetailViewModel):
                        //    detailViewModel = _meetingDetailViewModelCreator();
                        //    break;

                        //case nameof(ProgrammingLanguageDetailViewModel):
                        //    detailViewModel = _programmingLanguageDetailViewModelCreator();
                        //    break;
                }

                // Verify item still exists (may have been deleted)

                try
                {
                    await detailViewModel.LoadAsync(args.Id);
                }
                catch (Exception ex)
                {
                    _messageDialogService.ShowInfoDialog(
                        "Cannot load the entity, it may have been deleted" +
                        " by another user.  Updating Navigation");
                    await NavigationViewModel.LoadAsync();
                    return;
                }

                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        void AfterDetailClosed(AfterDetailClosedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var detailViewModel = DetailViewModels
                .SingleOrDefault(vm => vm.Id == id
                && vm.GetType().Name == viewModelName);

            if (detailViewModel != null)
            {
                DetailViewModels.Remove(detailViewModel);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        void OnOpenSingleDetailExecute(Type viewModelType)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            OnOpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = -1,
                    ViewModelName = viewModelType.Name
                });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
