using System;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Events;

using PrismApp2.Core.Events;
using PrismApp2.Domain;
using PrismApp2.DomainServices;
using PrismApp2.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PrismApp2.Presentation.ViewModels
{
    public class DogDetailViewModel : DetailViewModelBase, IDogDetailViewModel
    {
        private IDogDataService _dataService;
        private IEventAggregator _eventAggregator;

        public DogDetailViewModel(
                IDogDataService dataService,
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenDogDetailViewEvent>()
                .Subscribe(OnOpenDetailView);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        //private void OnOpenDetailView(AfterDogSavedEventArgs obj)
        //{
        //    Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

        //    throw new NotImplementedException();

        //    Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        //}

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(args.Id);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var item = id > 0
                ? await _dataService.FindByIdAsync(id)
                : CreateNewDog();

            Id = item.Id;

            InitializeDog(item);

            //InitializeFriendPhoneNumbers(friend.PhoneNumbers);

            //await LoadProgrammingLanguagesLookupAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
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
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

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

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{Type.FieldString}";
        }

        //private Task SaveWithOptimisticConcurrencyAsync(Task task, Action p)
        //{
        //    throw new NotImplementedException();
        //}

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await _dataService.UpdateAsync(Type.Model);

            HasChanges = false;
            Id = Type.Id;
            RaiseDetailSavedEvent(Type.Id, Type.FieldString);

            //await SaveWithOptimisticConcurrencyAsync(_dataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _dataService.HasChanges();
            //      Id = Type.Id;
            //      RaiseDetailSavedEvent(Type.Id, $"{Type.FieldString}");
            //  });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
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
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var result = MessageDialogService.ShowOkCancelDialog(
                "Do you really want to delete the Dog?", "Question");
            if (result == MessageDialogResult.OK)
            {
                await _dataService.DeleteAsync(Type.Id);
                RaiseDetailDeletedEvent(Type.Id);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnDeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        private Domain.Dog CreateNewDog()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

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

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);

            return item;
        }
    }
}
