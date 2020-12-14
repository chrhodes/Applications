using System;

using Prism.Events;

using PrismApp1.Core.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ViewModels
{
    public class DogNavigationItemViewModel : NavigationItemViewModel
    {
        //private IEventAggregator _eventAggregator;

        //private string _displayMember;
        //private string _detailViewModelName;

        public DogNavigationItemViewModel(
            int id,
            string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator) : base(id, displayMember, detailViewModelName, eventAggregator)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            //Id = id;
            //DisplayMember = displayMember;
            //_detailViewModelName = detailViewModelName;
            //_eventAggregator = eventAggregator;

            //OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        //public int Id { get; set; }

        //public string DisplayMember
        //{
        //    get { return _displayMember; }
        //    set
        //    {
        //        if (_displayMember == value)
        //            return;
        //        _displayMember = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand OpenDetailViewCommand { get; }

        public override void OnOpenDetailViewExecute()
        {
            Int64 startTicks = Log.VIEWMODEL(String.Format("Enter"), Common.LOG_APPNAME);

            switch (DetailViewModelName)
            {
                // case nameof(CatDetailViewModel):
                // _eventAggregator.GetEvent<OpenCatDetailViewEvent>()
                // .Publish
                // (
                // new OpenDetailViewEventArgs
                // {
                // Id = Id,
                // ViewModelName = _detailViewModelName
                // }
                // );
                // break;

                case nameof(DogDetailViewModel):
                    PublishOpenDogDetailViewEvent();
                    break;

                default:
                    throw new System.Exception($"NavigationItemViewModel.OnOpenDetailViewExecute():\nViewModel {DetailViewModelName} not mapped.");
            }

            //_eventAggregator.GetEvent<OpenDetailViewEvent>()
            //      .Publish
            //        (
            //            new OpenDetailViewEventArgs
            //            {
            //                Id = Id,
            //                ViewModelName = _detailViewModelName
            //            }
            //        );

            Log.VIEWMODEL(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private void PublishOpenDogDetailViewEvent()
        {
            Int64 startTicks = Log.EVENT(String.Format("Enter"), Common.LOG_APPNAME);

            EventAggregator.GetEvent<OpenDogDetailViewEvent>()
              .Publish
                (
                    new OpenDetailViewEventArgs
                    {
                        Id = Id,
                        ViewModelName = DetailViewModelName
                    }
                );

            Log.EVENT(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}

