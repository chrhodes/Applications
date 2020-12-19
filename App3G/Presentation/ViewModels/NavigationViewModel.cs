using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using App3.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace App3.Presentation.ViewModels
{
    public class NavigationViewModel : EventViewModelBase, INavigationViewModel
    {

        private IDogLookupDataService _lookupDataService;

        public ObservableCollection<NavigationItemViewModel> Dogs { get; }

        public NavigationViewModel(
                IEventAggregator eventAggregator,
                IDogLookupDataService lookupDataService,
                IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
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
            Int64 startTicks = Log.VIEWMODEL("(NavigationViewModel) Enter", Common.LOG_APPNAME);

            var lookupF = await _lookupDataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookupF)
            {
                Dogs.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DogDetailViewModel),
                    EventAggregator, MessageDialogService));
            }

            Log.VIEWMODEL("(NavigationViewModel) Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailSaved(Dogs, args);
                    break;

                // case nameof(CatDetailViewModel):
                // AfterDetailSaved(Cats, args);
                // break;                    

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_APPNAME);

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
