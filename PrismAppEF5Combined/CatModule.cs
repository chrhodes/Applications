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
    public class CatModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public CatModule(IRegionManager regionManager)
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

            containerRegistry.RegisterSingleton<ICatMainViewModel, CatMainViewModel>();
            containerRegistry.RegisterSingleton<ICatMain, CatMain>();

            containerRegistry.RegisterSingleton<ICatNavigationViewModel, CatNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICatNavigation, CatNavigation>();

            containerRegistry.Register<ICatDetailViewModel, CatDetailViewModel>();
            containerRegistry.Register<ICatDetail, CatDetail>();

            containerRegistry.RegisterSingleton<ICatLookupDataService, CatLookupDataService>();
            containerRegistry.RegisterSingleton<ICatDataService, CatDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            //this loads CatMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CatMainRegion, typeof(ICatMain));

            // These load into CatMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CatNavigationRegion, typeof(ICatNavigation));
            //_regionManager.RegisterViewWithRegion(RegionNames.CatDetailRegion, typeof(ICatDetail));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}