using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using PrismApp1.Core;
//using PrismApp1.DomainServices;

namespace PrismApp1.Presentation.Dog
{
    public class DogModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public DogModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // TODO(crhodes)
            // Should we be registering stuff here and not in App.Xaml.cs
            _container.RegisterType<ViewModels.IDogDetailViewModel, ViewModels.DogDetailViewModel>();
            _container.RegisterType<Views.IDogDetail, Views.DogDetail>();

            // TODO(crhodes)
            // Uncomment this when ready to pull in data

            //_container.RegisterType<IDogDataService, DogDataService>();

            _container.RegisterType<ViewModels.IDogViewModel, ViewModels.DogViewModel>();
            _container.RegisterType<Views.IDog, Views.Dog>();

            //_container.RegisterType<IDogLookupDataService, DogLookupDataService>();
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.DogRegion, typeof(Views.Dog));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(Views.DogDetail));
        }
    }
}