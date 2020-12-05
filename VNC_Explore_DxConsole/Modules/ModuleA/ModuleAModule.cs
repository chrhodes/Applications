using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Prism.Regions;
using Prism.Modularity;
using Prism.Regions;
using VNC_Explore_DxConsole.Infrastructure;
//using Unity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // Magic strings

            //_regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(ToolbarView));
            //_regionManager.RegisterViewWithRegion("ContentRegion", typeof(ContentView));

            // No more Magic Strings

            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));

            // Multiple Toolbar Regions

            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegionM_A];

            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionM_A, typeof(ContentView));
        }
    }
}
