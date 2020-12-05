using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using TestPrismApp1.Core.Events;
using TestPrismApp1.DomainServices;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace TestPrismApp1.Presentation.ViewModels
{
    class DogDetailViewModel : DetailViewModelBase, IDogDetailViewModel
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

            Type = await _dataService.FindByIdAsync(id);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private TestPrismApp1.Domain.Dog _type = new Domain.Dog();

        public TestPrismApp1.Domain.Dog Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        //public ICommand SaveCommand { get; private set; }

        protected override async void OnSaveExecute()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await _dataService.InsertAsync(Type);

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
    }
}
