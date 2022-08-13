using System;

using PAEF3.Core;
using PAEF3.DomainServices;
using PAEF3.Presentation.ViewModels;
using PAEF3.Presentation.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

namespace PAEF3
{
    public class PAEF3Module : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public PAEF3Module(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // This is where you pick the style of what gets loaded in the Shell.

            // If you are using the Ribbon Shell and the RibbonRegion

            containerRegistry.RegisterSingleton<IRibbonViewModel, RibbonViewModel>();
            containerRegistry.RegisterSingleton<IRibbon, Ribbon>();

            // Pick one of these for the MainRegion
            // Use Main to see the AutoWireViewModel in action.

            //containerRegistry.Register<IMain, Main>();            
            containerRegistry.Register<IMain, MainDxLayout>();
            //containerRegistry.Register<IMain, MainDxDockLayoutManager>();            

            containerRegistry.Register<ICombinedMainViewModel, CombinedMainViewModel>();
            containerRegistry.RegisterSingleton<ICombinedMain, CombinedMain>();

            containerRegistry.Register<ICombinedNavigationViewModel, CombinedNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICombinedNavigation, CombinedNavigation>();

            containerRegistry.Register<IToyDetailViewModel, ToyDetailViewModel>();
            containerRegistry.RegisterSingleton<IToyDetail, ToyDetail>();

            containerRegistry.RegisterSingleton<IToyDataService, ToyDataService>();
            containerRegistry.RegisterSingleton<IToyLookupDataService, ToyLookupDataService>();

            // This shows the AutoWire ViewModel in action. 

            containerRegistry.Register<ViewCViewModel>();
            containerRegistry.Register<ViewC>();
            containerRegistry.Register<ViewA>();
            containerRegistry.Register<ViewB>();

            containerRegistry.Register<IViewABCViewModel, ViewABCViewModel>();
            containerRegistry.Register<IViewABC, ViewABC>();

            // Figure out how to use one Type

            //containerRegistry.Register<IFriendLookupDataService, LookupDataService>();
            //containerRegistry.Register<IProgrammingLanguageLookupDataService, LookupDataService>();
            //containerRegistry.Register<IMeetingLookupDataService, LookupDataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(IRibbon));
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(IMain));

            //This loads CombinedMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedMainRegion, typeof(ICombinedMain));

            // These load into CombinedMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedNavigationRegion, typeof(ICombinedNavigation));

            // This is for Main and AutoWireViewModel demo

            _regionManager.RegisterViewWithRegion(RegionNames.ViewABCRegion, typeof(IViewABC));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewARegion, typeof(ViewA));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewBRegion, typeof(ViewB));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewCRegion, typeof(ViewC));

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
