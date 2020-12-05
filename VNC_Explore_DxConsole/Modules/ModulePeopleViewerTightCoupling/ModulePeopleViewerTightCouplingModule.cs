using PeopleViewer.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using VNCExploreConsole.Infrastructure;

namespace PeopleViewerTightCoupling
{
    public class PeopleViewerTightCouplingModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public PeopleViewerTightCouplingModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionY, typeof(Views.PeopleViewer));
        }
    }
}