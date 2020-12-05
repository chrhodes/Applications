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

    public class LineStatusNVDVViewModel : BindableBase
    {
        public ILineStatusNavigationViewModel NavigationViewModel { get; }

        public ILineStatusDetailViewModel DetailViewModel { get; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public LineStatusNVDVViewModel(
            ILineStatusNavigationViewModel lineStatusNaviagationViewModel,
            ILineStatusDetailViewModel lineStatusDetailViewModel)
        {
            try
            {
                // 22
                Message = "LineStatusNVDVViewModel";

                NavigationViewModel = lineStatusNaviagationViewModel;
                DetailViewModel = lineStatusDetailViewModel;
            }
            catch (Exception ex)
            {
                var foo = ex;
            }
        }

        public async Task LoadAsync()
        {
            // 34
            await NavigationViewModel.LoadAsync();
        }
    }
}
