using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using PAEF2.Domain;
using PAEF2.DomainServices;
using PAEF2.Presentation.ModelWrappers;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF2.Presentation.ViewModels
{
    public class DoorDetailViewModel : DetailViewModelBase, IDoorDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public DoorDetailViewModel(
            IDoorDataService DoorDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _DoorDataService = DoorDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            Title = "Doors";
            Doors = new ObservableCollection<DoorWrapper>();

            AddCommand = new DelegateCommand(AddExecute);
            RemoveCommand = new DelegateCommand(RemoveExecute, RemoveCanExecute);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)

        #endregion

        #region Structures (none)

        #endregion

        #region Fields and Properties

        private IDoorDataService _DoorDataService;

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        public ObservableCollection<DoorWrapper> Doors { get; private set; }

        private DoorWrapper _selectedDoor;

        public DoorWrapper SelectedDoor
        {
            get { return _selectedDoor; }
            set
            {
                _selectedDoor = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        // private async void OpenDetailView(OpenDetailViewEventArgs args)
        // {
        // Int64 startTicks = Log.EVENT("(DoorDetailViewModel) Enter", Common.LOG_CATEGORY);

        // await LoadAsync(args.Id);

        // Log.EVENT("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        // }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("(DoorDetailViewModel) Enter Id:({id})", Common.LOG_CATEGORY);

            Id = id;

            foreach (var wrapper in Doors)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            Doors.Clear();

            var items = await _DoorDataService.AllAsync();

            foreach (var model in items)
            {
                var wrapper = new DoorWrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                Doors.Add(wrapper);
            }

            Log.VIEWMODEL("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _DoorDataService.HasChanges();
            }

            if (e.PropertyName == nameof(DoorWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
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
            Int64 startTicks = Log.VIEWMODEL($"(DoorDetailViewModel) Enter Id:({SelectedDoor.Id})", Common.LOG_CATEGORY);

            Log.VIEWMODEL("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            return HasChanges && Doors.All(p => !p.HasErrors);
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(DoorDetailViewModel) Enter Id:({SelectedDoor.Id})", Common.LOG_CATEGORY);

            try
            {
                await _DoorDataService.UpdateAsync();

                HasChanges = _DoorDataService.HasChanges();

                PublishAfterCollectionSavedEvent();
            }
            catch (Exception ex)
            {
                // while (ex.InnerException != null)
                // {
                // ex = ex.InnerException;
                // }

                var message = "Error while saving the Doors, the data will be reloaded.  Details: " + ex;

                var dialogParameters = new DialogParameters();
                dialogParameters.Add("message", message);
                dialogParameters.Add("title", "Alert");

                DialogService.Show("NotificationDialog", dialogParameters, r =>
                {
                });

                await LoadAsync(Id);
            }

            Log.VIEWMODEL("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Private Methods

        void AddExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(DoorDetailViewModel) Enter", Common.LOG_CATEGORY);

            var wrapper = new DoorWrapper(new Domain.Door());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;

            _DoorDataService.Add(wrapper.Model);
            Doors.Add(wrapper);

            wrapper.Name = "";  // Trigger the validation

            Log.VIEWMODEL("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void RemoveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(DoorDetailViewModel) Enter", Common.LOG_CATEGORY);

            var isReferenced =
                await _DoorDataService.IsReferencedByCarAsync(SelectedDoor.Id);

            if (isReferenced)
            {
                var message = $"The Car ({SelectedDoor.Name})" +
                    " can't be removed;  It is referenced by at least one Car";

                DialogService.Show("NotificationDialog", new DialogParameters($"message={message}"), r =>
                {

                });

                return;
            }

            SelectedDoor.PropertyChanged -= Wrapper_PropertyChanged;
            _DoorDataService.Remove(SelectedDoor.Model);
            Doors.Remove(SelectedDoor);
            SelectedDoor = null;
            HasChanges = _DoorDataService.HasChanges();

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.VIEWMODEL("(DoorDetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        bool RemoveCanExecute()
        {
            return SelectedDoor != null;
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
