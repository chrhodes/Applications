using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Prism.Regions;
using VNCExploreConsole.Infrastructure;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleD
{

    public class ModuleDModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleDModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegionM_D, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionM_D, typeof(ContentView));
        }
    }
}
