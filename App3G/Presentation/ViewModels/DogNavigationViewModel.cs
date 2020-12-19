using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using App3.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace App3.Presentation.ViewModels
{
    public class DogNavigationViewModel : EventViewModelBase, IDogNavigationViewModel
    {
        private IDogLookupDataService _lookupDataService;

        private static int _instanceCountVM = 0;
        public ObservableCollection<NavigationItemViewModel> Dogs { get; }

        public DogNavigationViewModel(
                IEventAggregator eventAggregator,
                IMessageDialogService messageDialogService,
                IDogLookupDataService lookupDataService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountVM++;

            _lookupDataService = lookupDataService;

            Dogs = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(DogNavigationViewModel) Enter", Common.LOG_APPNAME);

            var lookupF = await _lookupDataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookupF)
            {
                Dogs.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DogDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            Log.VIEWMODEL("(DogNavigationViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailSaved(Dogs, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER($"Enter Id:({args.Id})", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailDeleted(Dogs, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
