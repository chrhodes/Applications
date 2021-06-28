using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using PAEF1.Animals.Domain;
using PAEF1.Animals.DomainServices;
using PAEF1.Animals.Presentation.ModelWrappers;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF1.Animals.Presentation.ViewModels
{
    public class BoneDetailViewModel : DetailViewModelBase, IBoneDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public BoneDetailViewModel(
            IBoneDataService BoneDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _BoneDataService = BoneDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            Title = "Bones";
            Bones = new ObservableCollection<BoneWrapper>();

            AddCommand = new DelegateCommand(AddExecute);
            RemoveCommand = new DelegateCommand(RemoveExecute, RemoveCanExecute);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums

        #endregion

        #region Structures

        #endregion

        #region Fields and Properties

        private IBoneDataService _BoneDataService;

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        public ObservableCollection<BoneWrapper> Bones { get; private set; }

        private BoneWrapper _selectedBone;

        public BoneWrapper SelectedBone
        {
            get { return _selectedBone; }
            set
            {
                _selectedBone = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        // private async void OpenDetailView(OpenDetailViewEventArgs args)
        // {
        // Int64 startTicks = Log.EVENT("(BoneDetailViewModel) Enter", Common.LOG_APPNAME);

        // await LoadAsync(args.Id);

        // Log.EVENT("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        // }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("(BoneDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            Id = id;

            foreach (var wrapper in Bones)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            Bones.Clear();

            var items = await _BoneDataService.AllAsync();

            foreach (var model in items)
            {
                var wrapper = new BoneWrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                Bones.Add(wrapper);
            }

            Log.VIEWMODEL("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _BoneDataService.HasChanges();
            }

            if (e.PropertyName == nameof(BoneWrapper.HasErrors))
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
            Int64 startTicks = Log.VIEWMODEL($"(BoneDetailViewModel) Enter Id:({SelectedBone.Id})", Common.LOG_APPNAME);

            Log.VIEWMODEL("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            return HasChanges && Bones.All(p => !p.HasErrors);
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(BoneDetailViewModel) Enter Id:({SelectedBone.Id})", Common.LOG_APPNAME);

            try
            {
                await _BoneDataService.UpdateAsync();

                HasChanges = _BoneDataService.HasChanges();

                PublishAfterCollectionSavedEvent();
            }
            catch (Exception ex)
            {
                // while (ex.InnerException != null)
                // {
                // ex = ex.InnerException;
                // }

                //MessageDialogService.ShowInfoDialog(
                //    "Error while saving the Bones, " +
                //    "the data will be reloaded.  Details: " + ex);

                var message = "Error while saving the Bones, " +
                    "the data will be reloaded.  Details: " + ex;

                DialogService.Show("NotificationDialog", new DialogParameters($"message={message}"), r =>
                {
                });

                await LoadAsync(Id);
            }

            Log.VIEWMODEL("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Private Methods

        void AddExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(BoneDetailViewModel) Enter", Common.LOG_APPNAME);

            var wrapper = new BoneWrapper(new Domain.Bone());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;

            _BoneDataService.Add(wrapper.Model);
            Bones.Add(wrapper);

            wrapper.Name = "";  // Trigger the validation

            Log.VIEWMODEL("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void RemoveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(BoneDetailViewModel) Enter", Common.LOG_APPNAME);

            var isReferenced =
                await _BoneDataService.IsReferencedByDogAsync(SelectedBone.Id);

            if (isReferenced)
            {
                //MessageDialogService.ShowInfoDialog(
                //    $"The Dog ({SelectedBone.Name})" +
                //    " can't be removed;  It is referenced by at least one Dog");

                var message = $"The Dog ({SelectedBone.Name})" +
                    " can't be removed;  It is referenced by at least one Dog";

                DialogService.Show("NotificationDialog", new DialogParameters($"message={message}"), r =>
                {
                });

                return;
            }

            SelectedBone.PropertyChanged -= Wrapper_PropertyChanged;
            _BoneDataService.Remove(SelectedBone.Model);
            Bones.Remove(SelectedBone);
            SelectedBone = null;
            HasChanges = _BoneDataService.HasChanges();

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.VIEWMODEL("(BoneDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        bool RemoveCanExecute()
        {
            return SelectedBone != null;
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
