using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Prism.Events;

using PrismApp2.DomainServices;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IDogLookupDataService _DogDataService;
        private IEventAggregator _eventAggregator;

        private static int _instanceCountVM = 0;
        public ObservableCollection<NavigationItemViewModel> Dogs { get; }
        public ObservableCollection<NavigationItemViewModel> Cats { get; }

        public NavigationViewModel(
                IEventAggregator eventAggregator,
                IDogLookupDataService DogLookupDataService)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _instanceCountVM++;
            _eventAggregator = eventAggregator;

            _DogDataService = DogLookupDataService;

            Dogs = new ObservableCollection<NavigationItemViewModel>();
            Cats = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            _eventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public int InstanceCountVM
        {
            get { return _instanceCountVM; }
            set { _instanceCountVM = value; }
        }

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookupF = await _DogDataService.GetDogLookupAsync();
            Dogs.Clear();

            foreach (var item in lookupF)
            {
                Dogs.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(DogDetailViewModel),
                    _eventAggregator));
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailSaved(Dogs, args);
                    break;

                case nameof(CatDetailViewModel):
                    AfterDetailSaved(Cats, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
        // TODO(crhodes)
        // Can this be pushed down?

        private void AfterDetailSaved(ObservableCollection<NavigationItemViewModel> items,
            AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookupItem = items.SingleOrDefault(l => l.Id == args.Id);

            if (lookupItem == null)
            {
                items.Add(new NavigationItemViewModel(args.Id, args.DisplayMember,
                    args.ViewModelName,
                    _eventAggregator));
            }
            else
            {
                lookupItem.DisplayMember = args.DisplayMember;
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(DogDetailViewModel):
                    AfterDetailDeleted(Dogs, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        void AfterDetailDeleted(ObservableCollection<NavigationItemViewModel> items,
            AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookupItem = items.SingleOrDefault(f => f.Id == args.Id);

            if (lookupItem != null)
            {
                items.Remove(lookupItem);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
