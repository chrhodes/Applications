using Microsoft.Practices.Unity;

using Prism.Modularity;
using Prism.Regions;

namespace ModuleRMS
{
    public class ModuleRMSModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleRMSModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType(typeof(object), typeof(ViewA), "ViewA");
            _container.RegisterType(typeof(object), typeof(ViewB), "ViewB");
            _container.RegisterType(typeof(object), typeof(ViewC), "ViewC");
            _container.RegisterType(typeof(object), typeof(ViewD), "ViewD");
        }
    }
}
