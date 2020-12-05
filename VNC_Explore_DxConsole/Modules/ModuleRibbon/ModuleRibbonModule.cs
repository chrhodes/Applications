using Microsoft.Practices.Unity;
using ModuleRibbon.Views;
using Prism.Modularity;
using Prism.Unity;

namespace ModuleRibbon
{
    public class ModuleRibbonModule : IModule
    {
        IUnityContainer _container;

        public ModuleRibbonModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            //register for nav
            _container.RegisterTypeForNavigation<ViewA>();
            _container.RegisterTypeForNavigation<ViewB>();
        }
    }
}
