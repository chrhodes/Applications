using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismAppEF1.Core;
using PrismAppEF1.DomainServices;
using PrismAppEF1.Presentation.ViewModels;
using PrismAppEF1.Presentation.Views;

using Unity;

using VNC;

namespace PrismAppEF1
{
    public class BirdModule : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public BirdModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<IBirdMainViewModel, BirdMainViewModel>();
            containerRegistry.RegisterSingleton<IBirdMain, BirdMain>();

            containerRegistry.Register<IBirdNavigationViewModel, BirdNavigationViewModel>();
            containerRegistry.RegisterSingleton<IBirdNavigation, BirdNavigation>();

            containerRegistry.Register<IBirdDetailViewModel, BirdDetailViewModel>();
            containerRegistry.RegisterSingleton<IBirdDetail, BirdDetail>();

            containerRegistry.RegisterSingleton<IBirdLookupDataService, BirdLookupDataService>();
            containerRegistry.Register<IBirdDataService, BirdDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)

            //this loads BirdMain into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.BirdMainRegion, typeof(IBirdMain));

            // These load into BirdMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.BirdNavigationRegion, typeof(IBirdNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.BirdDetailRegion, typeof(IBirdDetail));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}