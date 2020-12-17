using System;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Events;

using PrismAppEF5.Domain;
using PrismAppEF5.DomainServices;
using PrismAppEF5.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismAppEF5.Presentation.ViewModels
{
    public class CatDetailViewModel : DetailViewModelBase, ICatDetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public CatDetailViewModel(
                ICatDataService dataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _dataService = dataService;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums

        #endregion

        #region Structures

        #endregion

        #region Fields and Properties

        private ICatDataService _dataService;

        private CatWrapper _type;

        public CatWrapper Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Event Handlers

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            await LoadAsync(args.Id);

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("(CatDetailViewModel) Enter Id:({id})", Common.LOG_APPNAME);

            var item = id > 0
                ? await _dataService.FindByIdAsync(id)
                : CreateNewCat();

            Id = item.Id;

            InitializeCat(item);

            //InitializeFriendPhoneNumbers(friend.PhoneNumbers);

            //await LoadProgrammingLanguagesLookupAsync();

            Log.VIEWMODEL("(CatDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
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
            Int64 startTicks = Log.VIEWMODEL("(CatDetailViewModel) Enter Id:({Type.Id})", Common.LOG_APPNAME);

            var result = MessageDialogService.ShowOkCancelDialog(
                "Do you really want to delete the Cat?", "Question");
            if (result == MessageDialogResult.OK)
            {
                await _dataService.DeleteAsync(Type.Id);
                PublishAfterDetailDeletedEvent(Type.Id);
            }

            Log.VIEWMODEL("(CatDetailViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Type is valid or has changes
            // This enables and disables the button

            var result = Type != null
                && !Type.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("(CatDetailViewModel) Enter Id:({Type.Id})", Common.LOG_APPNAME);

            await _dataService.UpdateAsync(Type.Model);

            HasChanges = false;
            Id = Type.Id;

            PublishAfterDetailSavedEvent(Type.Id, Type.FieldString);

            //await SaveWithOptimisticConcurrencyAsync(_dataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _dataService.HasChanges();
            //      Id = Type.Id;
            //      RaiseDetailSavedEvent(Type.Id, $"{Type.FieldString}");
            //  });

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Private Methods

        private Domain.Cat CreateNewCat()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var item = new Domain.Cat();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;

            // TODO(crhodes)
            // Need to figure out how to handle creating new.
            // This tries to push all the way to the database which complains because
            // Haven't set Required Fields (e.g. FieldString)

            // This was our attempt to use our DataService later - but that creates a context and tries to add item which
            // throws exception

            //_dataService.Insert(item);

            // This is what was in Claudius Code (NB>  Add does not call Save Changes in his code
            //_friendRepository.Add(friend);

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);

            return item;
        }

        private void InitializeCat(Cat item)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            Type = new CatWrapper(item);

            Type.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = true;
                    //HasChanges = _dataService.HasChanges();
                }

                if (e.PropertyName == nameof(Type.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

                if (e.PropertyName == nameof(Type.FieldString))
                {
                    SetTitle();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            // Little trick to trigger the validation when creating new entries
            if (Type.Id == 0)
            {
                Type.FieldString = "";
            }

            SetTitle();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{Type.FieldString}";
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
