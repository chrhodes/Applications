using System;

using Prism.Mvvm;

using VNC;

namespace TestPrismApp1.Presentation.ViewModels
{
    public class NavigationItemViewModel : BindableBase
    {
        string _displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            Id = id;
            DisplayMember = displayMember;

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
                RaisePropertyChanged();
            }
        }
    }
}

