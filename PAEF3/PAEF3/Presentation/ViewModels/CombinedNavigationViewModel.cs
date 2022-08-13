﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using PAEF3.DomainServices;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace PAEF3.Presentation.ViewModels
{
    public class CombinedNavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CombinedNavigationViewModel(
            ICatLookupDataService CatLookupDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _CatLookupDataService = CatLookupDataService;

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            Cats = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private ICatLookupDataService _CatLookupDataService;

        public ObservableCollection<NavigationItemViewModel> Cats { get; private set; }

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(CatDetailViewModel):
                    AfterDetailSaved(Cats, args);
                    break;

                // case nameof(Cat2DetailViewModel):
                // AfterDetailSaved(Cat2s, args);
                // break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof(CatDetailViewModel):
                    AfterDetailDeleted(Cats, args);
                    break;

                // case nameof(Cat2DetailViewModel):
                // AfterDetailDeleted(Cat2s, args);
                // break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = Log.VIEWMODEL("(NavigationViewModel) Enter", Common.LOG_CATEGORY);

            var lookupCats = await _CatLookupDataService.GetCatLookupAsync();
            Cats.Clear();

            foreach (var item in lookupCats)
            {
                Cats.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(CatDetailViewModel),
                    EventAggregator, DialogService));
            }

            // var lookupCat2s = await _Cat2LookupDataService.GetCat2LookupAsync();
            // Cat2s.Clear();

            // foreach (var item in lookupCat2s)
            // {
            // Cat2s.Add(
            // new NavigationItemViewModel(item.Id, item.DisplayMember,
            // nameof(Cat2DetailViewModel),
            // EventAggregator, DialogService));
            // }

            //TODO(crhodes)
            // Load more TYPEs as needed here

            Log.VIEWMODEL("(NavigationViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


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
