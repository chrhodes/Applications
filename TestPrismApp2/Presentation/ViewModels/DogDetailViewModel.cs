using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using TestPrismApp2.Core.Events;
using TestPrismApp2.Domain;
using TestPrismApp2.DomainServices;
using TestPrismApp2.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace TestPrismApp2.Presentation.ViewModels
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
                .Subscribe(OnOpenDogDetailView);

            //SaveCommand = new DelegateCommand(
            //    OnSaveExecute, OnSaveCanExecute);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void OnOpenDogDetailView(AfterDogSavedEventArgs obj)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenDogDetailView(int typeId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //Type = await _dataService.FindByIdAsync(id);

            var dog = id > 0
                ? await _dataService.FindByIdAsync(id)
                : CreateNewDog();

            Id = dog.Id;

            InitializeDog(dog);

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

        private void InitializeDog(Dog dog)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            Type = new DogWrapper(dog);

            Type.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _dataService.HasChanges();
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
            RaiseDetailSavedEvent(Type.Id, Type.FieldString);

            //await SaveWithOptimisticConcurrencyAsync(_dataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _dataService.HasChanges();
            //      Id = Type.Id;
            //      RaiseDetailSavedEvent(Type.Id, $"{Type.FieldString}");
            //  });

            //await SaveWithOptimisticConcurrencyAsync(_dataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _dataService.HasChanges();
            //      Id = Type.Id;
            //      RaiseDetailSavedEvent(Type.Id, $"{Type.FieldString}");
            //  });

            //// Tell the Customer that we have updated something
            //_eventAggregator.GetEvent<AfterDogSavedEvent>()
            //    .Publish(new AfterDogSavedEventArgs
            //    {
            //        Id = Type.Id,
            //        DisplayMember = Type.FieldString
            //        //DisplayMember = $"{Type.FieldString} {Customer.LastName}"
            //    });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        //public ICommand DeleteCommand { get; private set; }

        protected override async void OnDeleteExecute()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await _dataService.DeleteAsync(Type.Id);

            //// Tell the Customer that we have updated something
            //_eventAggregator.GetEvent<AfterDogDeletedEvent>()
            //    .Publish(new AfterDogSavedEventArgs
            //    {
            //        Id = Type.Id,
            //        DisplayMember = Type.FieldString
            //        //DisplayMember = $"{Type.FieldString} {Customer.LastName}"
            //    });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override bool OnDeleteCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        private Domain.Dog CreateNewDog()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var item = new Domain.Dog();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;


            _dataService.Insert(item);
            //_friendRepository.Add(friend);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);

            return item;
        }
    }
}
