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

namespace ModuleC
{


    public class ModuleCModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleCModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegionM_C, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionM_C, typeof(ContentView));
        }
    }
}
