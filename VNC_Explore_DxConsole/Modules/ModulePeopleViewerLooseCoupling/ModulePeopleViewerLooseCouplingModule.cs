using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using VNCExploreConsole.Infrastructure;

namespace ModulePeopleViewerLooseCoupling
{
    public class ModulePeopleViewerLooseCouplingModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModulePeopleViewerLooseCouplingModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionZ, typeof(Views.PeopleViewer));
        }
    }
}