using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMLLinesEDMXCodeFirst;
using System.Collections.ObjectModel;
using LineStatusViewer.Data;
using System.ComponentModel;
using Infrastructure;

namespace LineStatusViewer.ViewModels
{
    // Go look at the implementation of BindableBase

    public class LineStatusViewModel : BindableBase
    {
        public ILineStatusDataService _lineStatusDataService { get; set; }

        AML_LineStatus _selectedLineStatus;

        public AML_LineStatus SelectedLineStatus
        {
            get { return _selectedLineStatus; }
            // This looks cool from BindableBase

            set { SetProperty(ref _selectedLineStatus, value); }
            //set
            //{
            //    if (_selectedLineStatus == value)
            //        return;
            //    _selectedLineStatus = value;
            //    // Compiler warning on this being deprecated.
            //    // Maybe a more current version handles this.

            //    //OnPropertyChanged(nameof(SelectedLineStatus));
            //    //OnPropertyChanged();
            //    //RaisePropertyChanged(nameof(SelectedLineStatus));
            //    RaisePropertyChanged();

            //}
        }
        
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ObservableCollection<AML_LineStatus> LineStatus { get; set; }

        public List<AML_LineStatus> LineInfo;

        public LineStatusViewModel(ILineStatusDataService lineStatusDataService)
        {
            try
            {
                // 14
                Message = "LineStatusViewModel";
                _lineStatusDataService = lineStatusDataService;
                LineStatus = new ObservableCollection<AML_LineStatus>();
            }
            catch (Exception ex)
            {
                var foo = ex;
            }
        }

        public void Load()
        {
            var lineStatus = _lineStatusDataService.GetAll();

            LineStatus.Clear();

            foreach (var line in lineStatus)
            {
                LineStatus.Add(line);
            }
        }

        public async Task LoadAsync()
        {
            // 38
            var lineStatus = await _lineStatusDataService.GetAllAsync();

            // Demo async loading.  UI should be responsive 
            //await Task.Delay(10000);

            LineStatus.Clear();

            foreach (var line in lineStatus)
            {
                LineStatus.Add(line);
            }
        }
    }
}
