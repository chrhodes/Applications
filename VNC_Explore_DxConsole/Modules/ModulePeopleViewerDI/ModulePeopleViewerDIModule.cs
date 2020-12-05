using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using VNCExploreConsole.Infrastructure;

namespace ModulePeopleViewerDI
{
    public class PeopleViewerDIModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public PeopleViewerDIModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionX, typeof(PeopleViewer.PeopleViewer));
        }
    }
}