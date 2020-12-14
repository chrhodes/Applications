using System;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Events;

using PrismApp1.Core.Events;
using PrismApp1.Domain;
using PrismApp1.DomainServices;
using PrismApp1.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismApp1.Presentation.ViewModels
{
    public class DogDetailViewModel : DetailViewModelBase, IDogDetailViewModel
    {
        private IDogDataService _dataService;
        //private IEventAggregator _eventAggregator;

        public DogDetailViewModel(
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService,
                IDogDataService dataService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _dataService = dataService;
            //_eventAggregator = eventAggregator;

            EventAggregator.GetEvent<OpenDogDetailViewEvent>()
                .Subscribe(OnOpenDetailView);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            await LoadAsync(args.Id);

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var item = id > 0
                ? await _dataService.FindByIdAsync(id)
                : CreateNewDog();

            Id = item.Id;

            InitializeDog(item);

            //InitializeFriendPhoneNumbers(friend.PhoneNumbers);

            //await LoadProgrammingLanguagesLookupAsync();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        private DogWrapper _type;

        public DogWrapper Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private void InitializeDog(Dog item)
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            Type = new DogWrapper(item);

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

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            await _dataService.UpdateAsync(Type.Model);

            HasChanges = false;
            Id = Type.Id;
            PublishDetailSavedEvent(Type.Id, Type.FieldString);

            //await SaveWithOptimisticConcurrencyAsync(_dataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _dataService.HasChanges();
            //      Id = Type.Id;
            //      RaiseDetailSavedEvent(Type.Id, $"{Type.FieldString}");
            //  });

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        protected virtual void PublishDetailDeletedEvent(int modelId)
        {
            long startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Publish
                (
                    new AfterDetailDeletedEventArgs
                    {
                        Id = modelId,
                        ViewModelName = this.GetType().Name
                    }
                );

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }

        protected virtual void PublishDetailSavedEvent(int modelId, string displayMember)
        {
            long startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Publish
                (
                    new AfterDetailSavedEventArgs
                    {
                        Id = modelId,
                        DisplayMember = displayMember,
                        ViewModelName = this.GetType().Name
                    }
                );

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
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

        protected override async void OnDeleteExecute()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var result = MessageDialogService.ShowOkCancelDialog(
                "Do you really want to delete the Dog?", "Question");
            if (result == MessageDialogResult.OK)
            {
                await _dataService.DeleteAsync(Type.Id);
                PublishDetailDeletedEvent(Type.Id);
            }

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnDeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        private Domain.Dog CreateNewDog()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            var item = new Domain.Dog();
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

        //protected virtual async Task SaveWithOptimisticConcurrencyAsync(Func<Task> saveFunc, Action afterSaveAction)
        //{
        //    Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

        //    try
        //    {
        //        await saveFunc();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        var databaseValues = ex.Entries.Single().GetDatabaseValues();

        //        if (databaseValues == null)
        //        {
        //            MessageDialogService.ShowInfoDialog(
        //                "The entity has been deleted by another user.  Cannot continue.");
        //            PublishDetailDeletedEvent(Id);
        //            return;
        //        }

        //        var result = MessageDialogService.ShowOkCancelDialog(
        //            "The entity has been changed by someone else." +
        //            " Click OK to save your changes anyway; Click Cancel" +
        //            " to reload the entity from the database.", "Question");

        //        if (result == MessageDialogResult.OK)   // Client Wins
        //        {
        //            // Update the original values with database-values
        //            var entry = ex.Entries.Single();
        //            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
        //            await saveFunc();
        //        }
        //        else  // Database Wins
        //        {
        //            // Reload entity from database
        //            await ex.Entries.Single().ReloadAsync();
        //            await LoadAsync(Id);
        //        }
        //    }

        //    // Do anything that needs to occur after saving

        //    afterSaveAction();

        //    Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        //}
    }
}
