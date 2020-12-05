using LineStatusBodyShopViewer.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Infrastructure;

namespace LineStatusBodyShopViewer
{
    public class LineStatusBodyShopViewerModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public LineStatusBodyShopViewerModule(IUnityContainer container, IRegionManager regionManager)
        {
            // 29
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // 30
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusBodyShop, typeof(LineStatusBodyShopView));
        }
    }
}