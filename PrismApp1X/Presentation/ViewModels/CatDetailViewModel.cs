using System.Threading.Tasks;

using PrismApp1.Core.Events;
//using PrismApp1.DomainServices;
using Prism.Events;

using VNC.Core.Mvvm;
using System;
using System.Windows.Input;
using Prism.Commands;
using PrismApp1.DomainServices;
using VNC;

namespace PrismApp1.Presentation.ViewModels
{
    class CatDetailViewModel : ViewModelBase, ICatDetailViewModel
    {
        private ICatDataService _dataService;
        private IEventAggregator _eventAggregator;

        public CatDetailViewModel(
                ICatDataService dataService,
                IEventAggregator eventAggregator)
        {
            Int64 startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenCatDetailViewEvent>()
                .Subscribe(OnOpenCatDetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void OnOpenCatDetailView(AfterCatSavedEventArgs obj)
        {
            Int64 startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

            throw new NotImplementedException();
        }

        private async void OnOpenCatDetailView(int typeId)
        {
            Int64 startTicks = Log.Info($"Enter", Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync(int id)
        {
            Int64 startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            Type = await _dataService.FindByIdAsync(id);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private PrismApp1.Domain.Cat _type;

        public PrismApp1.Domain.Cat Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        async void OnSaveExecute()
        {
            Int64 startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            await _dataService.UpdateAsync(Type);

            // Tell the Customer that we have updated something
            _eventAggregator.GetEvent<AfterCatSavedEvent>()
                .Publish(new AfterCatSavedEventArgs
                {
                    Id = Type.Id,
                    DisplayMember = Type.FieldString
                    //DisplayMember = $"{Type.FieldString} {Customer.LastName}"
                });

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        bool OnSaveCanExecute()
        {
            Int64 startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Check if Customer is valid

            Log.Trace($"Exit (true)", Common.LOG_APPNAME, startTicks);
            return true;
        }
    }
}
