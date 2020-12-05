using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using VNCExploreConsole.Infrastructure;

namespace ModuleR
{
    public class ModuleRModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleRModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // View Discovery
            _regionManager.RegisterViewWithRegion("ChildRegion", typeof(ViewB));

            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];

            //// This works.

            //var view1 = _container.Resolve<ViewA>();
            //region.Add(view1);
            //region.Activate(view1);

            //// But when we add the second view, the region complains about duplicates
            //// - "ChildRegion" already exists.

            //var view2 = _container.Resolve<ViewA>();
            //region.Add(view2);
            //region.Activate(view2);

            //var view3 = _container.Resolve<ViewA>();
            //region.Add(view3);
            //region.Activate(view3);

            var view1 = _container.Resolve<ViewA>();
            IRegionManager r1 = region.Add(view1, null, true);
            region.Activate(view1);

            var view2 = _container.Resolve<ViewA>();
            IRegionManager r2 = region.Add(view2, null, true);
            region.Activate(view2);

            var view3 = _container.Resolve<ViewA>();
            IRegionManager r3 = region.Add(view3, null, true);
            region.Activate(view3);
        }
    }
}
