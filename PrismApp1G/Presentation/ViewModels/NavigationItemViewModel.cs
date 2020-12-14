using System;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        private string _displayMember;
        private string _detailViewModelName;

        public NavigationItemViewModel(
            int id,
            string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            Id = id;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            _eventAggregator = eventAggregator;

            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public int Id { get; set; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                if (_displayMember == value)
                    return;
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpenDetailViewExecute()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                  .Publish
                    (
                        new OpenDetailViewEventArgs
                        {
                            Id = Id,
                            ViewModelName = _detailViewModelName
                        }
                    );

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}

