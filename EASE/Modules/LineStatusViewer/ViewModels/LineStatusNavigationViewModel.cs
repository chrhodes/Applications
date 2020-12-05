using LineStatusViewer.Data;
using LineStatusViewer.Events;
using LineStatusViewer.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LineStatusViewer.ViewModels
{
    public class LineStatusNavigationViewModel : BindableBase, ILineStatusNavigationViewModel
    {
        private ILookupBuildsService _lookupBuildsService;

        public IEventAggregator _eventAggregator { get; set; }

        public ObservableCollection<BuildItem> Builds { get; }

        public LineStatusNavigationViewModel(
            ILookupBuildsService lookupBuildsService,
            IEventAggregator eventAggregator)
        {
            try
            {
                // 19
                // 25
                Message = "LineStatusNavigationViewModel";

                _lookupBuildsService = lookupBuildsService;
                _eventAggregator = eventAggregator;
                Builds = new ObservableCollection<BuildItem>();

                _eventAggregator.GetEvent<AfterLineStatusSavedEvent>().Subscribe(AfterLineStatusSaved);
            }
            catch (Exception ex)
            {
                var foo = ex;
            }
        }

        async void AfterLineStatusSaved(AfterLineStatusSavedEventArgs obj)
        {
            // S5

            // This returns nothing because we are passed the new BuildItem not the old one
            // that was selected to load the LineStatusDetail

            //var buildItem = Builds.Single(n => n.LineId == obj.BuildItem.LineId
            //            && n.StationNO == obj.BuildItem.StationNO
            //            && n.BuildNo == obj.BuildItem.BuildNo);

            // This does not error but doesn't do anything.

            //SelectedBuildItem.LineId = obj.BuildItem.LineId;
            //SelectedBuildItem.StationNO = obj.BuildItem.StationNO;
            //SelectedBuildItem.BuildNo = obj.BuildItem.BuildNo;

            // Maybe we need to Load Again?

            await LoadAsync();

            // Now the problem is the SelectedBuildItem is not set to the right info if the BuildItem Changed
            // So reset it to the new value passed in EventArgs

            SelectedBuildItem = obj.BuildItem;

            // We cannot be more clever and avoid reloading the LineStatusDetailView
            // See publish below if we update the backing field directly.  As someone doesn't
            // get notified and some sequence returns no items

            //_selectedBuildItem = obj.BuildItem;

        }

        BuildItem _selectedBuildItem;

        public BuildItem SelectedBuildItem
        {
            get
            {
                // B5
                return _selectedBuildItem;
            }
            set
            {
                _selectedBuildItem = value;
                OnPropertyChanged();

                if (_selectedBuildItem != null)
                {
                    
                    // B1
                    //_eventAggregator.GetEvent<OpenLineStatusDetailViewEvent>()
                    //    .Publish(_selectedBuild.BuildNo);
                    _eventAggregator.GetEvent<OpenLineStatusDetailViewEvent>()
                        .Publish(_selectedBuildItem);
                }
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public async Task LoadAsync()
        {
            // 35
            var lookup = await _lookupBuildsService.GetBuildsAsync();
            Builds.Clear();

            foreach (var item in lookup)
            {
                Builds.Add(item);
            }
        }
    }
}
