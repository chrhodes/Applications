using System;

using PAEF2.Core;
using PAEF2.DomainServices;
using PAEF2.Presentation.ViewModels;
using PAEF2.Presentation.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

namespace PAEF2
{
    public class CarModule : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public CarModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            containerRegistry.Register<ICarMainViewModel, CarMainViewModel>();
            containerRegistry.RegisterSingleton<ICarMain, CarMain>();

            containerRegistry.Register<ICarNavigationViewModel, CarNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICarNavigation, CarNavigation>();

            containerRegistry.Register<ICarDetailViewModel, CarDetailViewModel>();
            containerRegistry.RegisterSingleton<ICarDetail, CarDetail>();

            containerRegistry.RegisterSingleton<ICarLookupDataService, CarLookupDataService>();
            containerRegistry.Register<ICarDataService, CarDataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)

            //this loads CarMain into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CarMainRegion, typeof(ICarMain));

            // These load into CarMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CarNavigationRegion, typeof(ICarNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.CarDetailRegion, typeof(ICarDetail));

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
