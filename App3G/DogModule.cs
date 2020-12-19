using System;

using App3.Core;
using App3.DomainServices;
using App3.Presentation.ViewModels;
using App3.Presentation.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

namespace App3
{
    public class DogModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public DogModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            //_container = container;
            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<IDogMainViewModel, DogMainViewModel>();
            containerRegistry.Register<IDogMain, DogMain>();

            containerRegistry.RegisterSingleton<INavigationViewModel, NavigationViewModel>();
            containerRegistry.RegisterSingleton<INavigation, Navigation>();

            containerRegistry.Register<IDogDetailViewModel, DogDetailViewModel>();
            containerRegistry.Register<IDogDetail, DogDetail>();

            containerRegistry.RegisterSingleton<IDogLookupDataService, DogLookupDataService>();
            containerRegistry.RegisterSingleton<IDogDataService, DogDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            //this loads DogMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.DogMainRegion, typeof(DogMain));

            // These load into DogMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(Navigation));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(DogDetail));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}