using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using PrismAppEF1.Domain;
using PrismAppEF1.DomainServices;
using PrismAppEF1.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismAppEF1.Presentation.ViewModels
{
    public class SongDetailViewModel : DetailViewModelBase, ISongDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public SongDetailViewModel(
                ISongDataService SongDataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _SongDataService = SongDataService;

            Title = "Songs";
            Songs = new ObservableCollection<SongWrapper>();

            AddCommand = new DelegateCommand(OnAddExecute);
            RemoveCommand = new DelegateCommand(OnRemoveExecute, OnRemoveCanExecute);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums

        #endregion

        #region Structures

        #endregion

        #region Fields and Properties

        private ISongDataService _SongDataService;

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public ObservableCollection<SongWrapper> Songs { get; }

        private SongWrapper _selectedSong;

        public SongWrapper SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        // private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        // {
        // Int64 startTicks = Log.EVENT("(SongDetailViewModel) Enter", Common.LOG_APPNAME);

        // await LoadAsync(args.Id);

        // Log.EVENT("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        // }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("(SongDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            Id = id;

            foreach (var wrapper in Songs)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            Songs.Clear();

            var items = await _SongDataService.AllAsync();

            foreach (var model in items)
            {
                var wrapper = new SongWrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                Songs.Add(wrapper);
            }

            Log.VIEWMODEL("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _SongDataService.HasChanges();
            }

            if (e.PropertyName == nameof(SongWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Protected Methods

        protected override bool OnDeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        protected override async void OnDeleteExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(SongDetailViewModel) Enter Id:({SelectedSong.Id})", Common.LOG_APPNAME);

            Log.VIEWMODEL("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnSaveCanExecute()
        {
            return HasChanges && Songs.All(p => !p.HasErrors);
        }

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL($"(SongDetailViewModel) Enter Id:({SelectedSong.Id})", Common.LOG_APPNAME);

            try
            {
                await _SongDataService.UpdateAsync();

                HasChanges = _SongDataService.HasChanges();

                PublishAfterCollectionSavedEvent();
            }
            catch (Exception ex)
            {
                // while (ex.InnerException != null)
                // {
                // ex = ex.InnerException;
                // }

                MessageDialogService.ShowInfoDialog(
                    "Error while saving the Songs, " +
                    "the data will be reloaded.  Details: " + ex);
                await LoadAsync(Id);
            }

            Log.VIEWMODEL("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Private Methods

        void OnAddExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(SongDetailViewModel) Enter", Common.LOG_APPNAME);

            var wrapper = new SongWrapper(new Domain.Song());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;

            _SongDataService.Add(wrapper.Model);
            Songs.Add(wrapper);

            wrapper.Name = "";  // Trigger the validation

            Log.VIEWMODEL("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void OnRemoveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(SongDetailViewModel) Enter", Common.LOG_APPNAME);

            var isReferenced =
                await _SongDataService.IsReferencedByBirdAsync(SelectedSong.Id);

            if (isReferenced)
            {
                MessageDialogService.ShowInfoDialog(
                    $"The Song ({SelectedSong.Name})" +
                    " can't be removed;  It is referenced by at least one Bird");
                return;
            }

            SelectedSong.PropertyChanged -= Wrapper_PropertyChanged;
            _SongDataService.Remove(SelectedSong.Model);
            Songs.Remove(SelectedSong);
            SelectedSong = null;
            HasChanges = _SongDataService.HasChanges();

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            Log.VIEWMODEL("(SongDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        bool OnRemoveCanExecute()
        {
            return SelectedSong != null;
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
