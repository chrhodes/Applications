using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismApp2.Core;
using PrismApp2.DomainServices;
using PrismApp2.Presentation.ViewModels;
using PrismApp2.Presentation.Views;

using Unity;

using VNC;

namespace PrismApp2
{
    public class CatModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public CatModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.MODULE(String.Format("Enter"), Common.LOG_APPNAME);

            //_container = container;
            _regionManager = regionManager;

            Log.MODULE(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        /// <summary>
        /// 02
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE_INITIALIZE(String.Format("Enter"), Common.LOG_APPNAME);

            containerRegistry.Register<ICatDetailViewModel, CatDetailViewModel>();
            containerRegistry.Register<ICatDetail, CatDetail>();

            containerRegistry.Register<ICatMainViewModel, CatMainViewModel>();
            containerRegistry.Register<ICatMain, CatMain>();

            containerRegistry.RegisterSingleton<ICatNavigationViewModel, CatNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICatNavigation, CatNavigation>();

            containerRegistry.RegisterSingleton<ICatLookupDataService, CatLookupDataService>();
            containerRegistry.RegisterSingleton<ICatDataService, CatDataService>();

            Log.MODULE_INITIALIZE(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        /// <summary>
        /// 03
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE_INITIALIZE(String.Format("Enter"), Common.LOG_APPNAME);

            //this loads CatMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CatMainRegion, typeof(CatMain));

            // These load into CatMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CatNavigationRegion, typeof(CatNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.CatDetailRegion, typeof(CatDetail));

            Log.MODULE_INITIALIZE(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }


    }
}