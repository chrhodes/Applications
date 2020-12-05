using System.Windows.Controls;
using Prism.Regions;
using Prism.Common;
using ModuleInterfaces;
using VNC.Core.Mvvm;
using PrismDemo.Domain;

namespace ModulePeople
{
    public partial class PersonDetails : UserControl, IPersonDetails
    {
        // This is a view first approach.  View passes in ViewModel

        public PersonDetails(IPersonDetailsViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            ViewModel.View = this;

            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
                {
                    var context = (ObservableObject<object>)s;
                    // Generally avoid passing whole person into view.  Just the parts needed.  This is just for demo.
                    // Normally just pass ID or something than can be used to retrieve data from ViewModel
                    var selectedPerson = (Person)context.Value;
                    (ViewModel as IPersonDetailsViewModel).SelectedPerson = selectedPerson;
                };
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
