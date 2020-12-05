using VNCExploreConsole.Infrastructure;
using Microsoft.Practices.Unity;
using ModuleInterfaces;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleToolBar
{
    public class ToolbarModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ToolbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var vm = _container.Resolve<IToolBarViewModel>();
            _regionManager.Regions[RegionNames.ToolbarRegionC_CC].Add(vm.View);
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IToolBarViewModel, ToolBarViewModel>();
            _container.RegisterType<IToolBar, ToolBar>();
        }
    }
}
