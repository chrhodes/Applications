using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using TestPrismApp2.Core;
using TestPrismApp2.DomainServices;
using TestPrismApp2.Presentation.ViewModels;
using TestPrismApp2.Presentation.Views;

using VNC;

namespace TestPrismApp2
{
    public class DogModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public DogModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //_container = container;
            _regionManager = regionManager;
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            containerRegistry.Register<Presentation.ViewModels.IDogDetailViewModel, Presentation.ViewModels.DogDetailViewModel>();
            containerRegistry.Register<Presentation.Views.IDogDetail, Presentation.Views.DogDetail>();

            containerRegistry.Register<IDogDataService, DogDataService>();

            containerRegistry.Register<Presentation.ViewModels.IDogMainViewModel, Presentation.ViewModels.DogMainViewModel>();
            containerRegistry.Register<Presentation.Views.IDogMain, Presentation.Views.DogMain>();

            containerRegistry.RegisterSingleton<INavigationViewModel, NavigationViewModel>();
            containerRegistry.RegisterSingleton<INavigation, DogNavigation>();

            containerRegistry.Register<IDogLookupDataService, LookupDataService>();
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //this loads DogMain into the MainWindow loaded in App.Xaml.cs

            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Presentation.Views.DogMain));

            _regionManager.RegisterViewWithRegion(RegionNames.DogNavigationRegion, typeof(Presentation.Views.DogNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(Presentation.Views.DogDetail));
        }
    }
}