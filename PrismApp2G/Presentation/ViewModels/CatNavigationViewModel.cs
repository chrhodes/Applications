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
    public class CatNavigationViewModel : ViewModelBase, ICatNavigationViewModel
    {
        private ICatLookupDataService _lookupDataService;
        private IEventAggregator _eventAggregator;

        private static int _instanceCountVM = 0;
        public ObservableCollection<NavigationItemViewModel> Cats { get; }

        public CatNavigationViewModel(
                IEventAggregator eventAggregator,
                ICatLookupDataService lookupDataService)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _instanceCountVM++;
            _eventAggregator = eventAggregator;

            _lookupDataService = lookupDataService;

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

            var lookupF = await _lookupDataService.GetCatLookupAsync();
            Cats.Clear();

            foreach (var item in lookupF)
            {
                Cats.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(CatDetailViewModel),
                    _eventAggregator));
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            switch (args.ViewModelName)
            {
                case nameof(CatDetailViewModel):
                    AfterDetailSaved(Cats, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Can't this be pushed down to base class?
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
                case nameof(CatDetailViewModel):
                    AfterDetailDeleted(Cats, args);
                    break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Can't this be pushed down to base class?

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
