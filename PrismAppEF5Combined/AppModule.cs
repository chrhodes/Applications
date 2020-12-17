using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismAppEF5.Core;
using PrismAppEF5.DomainServices;
using PrismAppEF5.Presentation.ViewModels;
using PrismAppEF5.Presentation.Views;

using Unity;

using VNC;

namespace PrismAppEF5
{
    public class AppModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public AppModule(IRegionManager regionManager)
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

            containerRegistry.Register<ICombinedMainViewModel, CombinedMainViewModel>();
            containerRegistry.Register<ICombinedMain, CombinedMain>();

            containerRegistry.Register<ICombinedNavigationViewModel, NavigationViewModel>();
            containerRegistry.Register<INavigation, Navigation>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            //this loads CombineMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedMainRegion, typeof(ICombinedMain));

            // These load into DogMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedNavigationRegion, typeof(INavigation));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}