using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using VNC.Core.Mvvm.Prism;
using VNCExploreConsole.Infrastructure;

namespace ModuleRMS.ViewModels
{
    public class ViewCViewModel : BindableBase, IRegionManagerAware
    {
        public DelegateCommand NavigateCommand { get; set; }

        public ViewCViewModel()
        {
            NavigateCommand = new DelegateCommand(Navigate);
        }

        void Navigate()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public IRegionManager RegionManager { get; set; }
    }
}
