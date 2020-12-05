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

namespace ModuleB
{
    // Can put attributes on Modules
    [Module(ModuleName = "ModuleB", OnDemand = true)]
    [ModuleDependency("ModuleC")]
    public class ModuleBModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleBModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegionM_B, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionM_B, typeof(ContentView));
        }
    }
}
