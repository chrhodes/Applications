using Prism.Mvvm;

using System;
using System.Threading.Tasks;

using VNC;

namespace PrismApp1.ViewModels
{
    public class MainWindowDxViewModel : BindableBase
    {
        // ObservableCollection notifies databinding when collection changes
        // because it implements INotifyCollectionChanged

        //public ObservableCollection<Address> Addresses { get; set; }

        //public ObservableCollection<Material> Materials { get; set; }

        //public IAddressDataService _addressDataService { get; set; }

        //public IMaterialDataService _materialDataService { get; set; }
        public MainWindowDxViewModel()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            Log.Debug($"Exit", Common.LOG_APPNAME, startTicks);
        }
        //public MainWindowDxViewModel(
        //            IAddressDataService addressDataService,
        //            IMaterialDataService materialDataService)
        //{
        //    _addressDataService = addressDataService;
        //    _materialDataService = materialDataService;

        //    Addresses = new ObservableCollection<Address>();
        //    Materials = new ObservableCollection<Material>();
        //}

        #region This goes away with the new NavigationViewModel


        //Address _selectedAddress;

        //public Address SelectedAddress
        //{
        //    get { return _selectedAddress; }
        //    set
        //    {
        //        _selectedAddress = value;

        //        RaisePropertyChanged();
        //        // TODO(crhodes)
        //        // Learn what SetProperty does
        //        //SetProperty(ref _selectedCustomer, value);
        //    }
        //}

        //Material _selectedMaterial;

        //public Material SelectedMaterial
        //{
        //    get { return _selectedMaterial; }
        //    set
        //    {
        //        _selectedMaterial = value;

        //        RaisePropertyChanged();
        //        SetProperty(ref _selectedMaterial, value);
        //    }
        //}

        #endregion

        #region Move to Async loading

        //public void Load()
        //{
        //    LoadAddresses();
        //    LoadMaterials();
        //}

        //public async Task LoadAsync()
        //{
        //    await LoadAddressesAsync();
        //    await LoadMaterialsAsync();
        //}

        //private void LoadAddresses()
        //{
        //    var addresses = _addressDataService.All();

        //    Addresses.Clear();

        //    foreach (var address in addresses)
        //    {
        //        Addresses.Add(address);
        //    }
        //}

        //public async Task LoadAddressesAsync()
        //{
        //    var addresses = await _addressDataService.AllAsync();

        //    Addresses.Clear();

        //    foreach (var address in addresses)
        //    {
        //        Addresses.Add(address);
        //    }
        //}

        //private void LoadMaterials()
        //{
        //    var materials = _materialDataService.All();

        //    Materials.Clear();

        //    foreach (var material in materials)
        //    {
        //        Materials.Add(material);
        //    }
        //}

        //public async Task LoadMaterialsAsync()
        //{
        //    var materials = await _materialDataService.AllAsync();

        //    Materials.Clear();

        //    foreach (var material in materials)
        //    {
        //        Materials.Add(material);
        //    }
        //}

        #endregion

    }
}
