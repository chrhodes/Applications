using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using WPFBinding101.Domain;
using WPFBinding101.DomainServices;
using WPFBinding101.Presentation.ModelWrappers;

namespace WPFBinding101.Presentation.ViewModels
{
    public class SeedDetailViewModel : DetailViewModelBase, ISeedDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public SeedDetailViewModel(
            ISeedDataService SeedDataService,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _SeedDataService = SeedDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            Title = "Seeds";
            Seeds = new ObservableCollection<SeedWrapper>();

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

        private ISeedDataService _SeedDataService;

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        public ObservableCollection<SeedWrapper> Seeds { get; private set; }

        private SeedWrapper _selectedSeed;

        public SeedWrapper SelectedSeed
        {
            get { return _selectedSeed; }
            set
            {
                _selectedSeed = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        // private async void OpenDetailView(OpenDetailViewEventArgs args)
        // {
        // Int64 startTicks = Log.EVENT("(SeedDetailViewModel) Enter", Common.LOG_APPNAME);

        // await LoadAsync(args.Id);

        // Log.EVENT("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        // }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("(SeedDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            Id = id;

            foreach (var wrapper in Seeds)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            Seeds.Clear();

            var items = await _SeedDataService.AllAsync();

            foreach (var model in items)
            {
                var wrapper = new SeedWrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                Seeds.Add(wrapper);
            }

            Log.VIEWMODEL("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _SeedDataService.HasChanges();
            }

            if (e.PropertyName == nameof(SeedWrapper.HasErrors))
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
            Int64 startTicks = Log.VIEWMODEL($"(SeedDetailViewModel) Enter Id:({SelectedSeed.Id})", Common.LOG_APPNAME);

            Log.VIEWMODEL("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            return HasChanges && Seeds.All(p => !p.HasErrors);
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(SeedDetailViewModel) Enter Id:({SelectedSeed.Id})", Common.LOG_APPNAME);

            try
            {
                await _SeedDataService.UpdateAsync();

                HasChanges = _SeedDataService.HasChanges();

                PublishAfterCollectionSavedEvent();
            }
            catch (Exception ex)
            {
                // while (ex.InnerException != null)
                // {
                // ex = ex.InnerException;
                // }

                MessageDialogService.ShowInfoDialog(
                    "Error while saving the Seeds, " +
                    "the data will be reloaded.  Details: " + ex);
                await LoadAsync(Id);
            }

            Log.VIEWMODEL("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Private Methods

        void AddExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(SeedDetailViewModel) Enter", Common.LOG_APPNAME);

            var wrapper = new SeedWrapper(new Domain.Seed());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;

            _SeedDataService.Add(wrapper.Model);
            Seeds.Add(wrapper);

            wrapper.Name = "";  // Trigger the validation

            Log.VIEWMODEL("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void RemoveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(SeedDetailViewModel) Enter", Common.LOG_APPNAME);

            var isReferenced =
                await _SeedDataService.IsReferencedByBirdAsync(SelectedSeed.Id);

            if (isReferenced)
            {
                MessageDialogService.ShowInfoDialog(
                    $"The Bird ({SelectedSeed.Name})" +
                    " can't be removed;  It is referenced by at least one Bird");
                return;
            }

            SelectedSeed.PropertyChanged -= Wrapper_PropertyChanged;
            _SeedDataService.Remove(SelectedSeed.Model);
            Seeds.Remove(SelectedSeed);
            SelectedSeed = null;
            HasChanges = _SeedDataService.HasChanges();

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.VIEWMODEL("(SeedDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        bool RemoveCanExecute()
        {
            return SelectedSeed != null;
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
