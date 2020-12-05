using Microsoft.Practices.Unity;
using VNCExploreConsole.Infrastructure;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleSimpleView
{
    public class ModuleSimpleViewModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        // Need a container so we can register our views
        // and a RegionManager so we can compose views and perform View discovery.
        // Prism will pass in when this module is created.

        public ModuleSimpleViewModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _regionManager = manager;
        }

        public void Initialize()
        {
            // 1. Register Views
            // Nothing happens other thn Unity knows about View

            //_container.RegisterType<ToolbarA>();  // If this is commented out, still works!
            //_container.RegisterType<ContentA>();  // If this is commented out, still works!

            // 2. Tell the Region where the View goes.
            // NB. This also registers the type

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegionV_SV, typeof(ToolbarA));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionV_SV, typeof(ContentA));
        }
    }
}
