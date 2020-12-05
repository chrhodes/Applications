using Microsoft.Practices.Unity;
using ModuleInterfaces;
using Prism.Modularity;
using Prism.Regions;
using VNCExploreConsole.Infrastructure;

namespace ModuleSBN
{
    public class ModuleSBNModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _manager;

        public ModuleSBNModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }

        public void Initialize()
        {
            _container.RegisterType<IContentSBN, ContentSBN>();
            _container.RegisterType<IContentSBNViewModel, ContentSBNViewModel>();

            _manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentSBN));
        }
    }
}
