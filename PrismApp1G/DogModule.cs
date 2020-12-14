using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismApp1.Core;
using PrismApp1.DomainServices;
using PrismApp1.Presentation.ViewModels;
using PrismApp1.Presentation.Views;

using Unity;

using VNC;

namespace PrismApp1
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

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            containerRegistry.Register<IDogMainViewModel, DogMainViewModel>();
            containerRegistry.Register<IDogMain, DogMain>();

            //containerRegistry.RegisterSingleton<INavigationViewModel, NavigationViewModel>();
            containerRegistry.RegisterSingleton<INavigation, DogNavigation>();

            containerRegistry.Register<IDogDetailViewModel, DogDetailViewModel>();
            containerRegistry.Register<IDogDetail, DogDetail>();

            //containerRegistry.RegisterSingleton<IDogDataService, DogDataService>();
            //containerRegistry.RegisterSingleton<IDogLookupDataService, DogLookupDataService>();

            containerRegistry.Register<IDogDataService, DogDataService>();
            containerRegistry.Register<IDogLookupDataService, DogLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //this loads DogMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.DogMainRegion, typeof(DogMain));

            // These load into DogMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.DogNavigationRegion, typeof(DogNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(DogDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}