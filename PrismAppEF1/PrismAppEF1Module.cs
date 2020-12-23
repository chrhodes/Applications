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
    public class PrismAppEF1Module : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public PrismAppEF1Module(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<ICombinedMainViewModel, CombinedMainViewModel>();
            containerRegistry.RegisterSingleton<ICombinedMain, CombinedMain>();

            containerRegistry.Register<ICombinedNavigationViewModel, CombinedNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICombinedNavigation, CombinedNavigation>();

            containerRegistry.Register<ISongDetailViewModel, SongDetailViewModel>();
            containerRegistry.RegisterSingleton<ISongDetail, SongDetail>();

            containerRegistry.RegisterSingleton<ISongDataService, SongDataService>();
            containerRegistry.RegisterSingleton<ISongLookupDataService, SongLookupDataService>();

            // Figure out how to use one Type

            //containerRegistry.Register<IFriendLookupDataService, LookupDataService>();
            //containerRegistry.Register<IProgrammingLanguageLookupDataService, LookupDataService>();
            //containerRegistry.Register<IMeetingLookupDataService, LookupDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            //This loads CombinedMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedMainRegion, typeof(ICombinedMain));

            // These load into CombinedMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.CombinedNavigationRegion, typeof(ICombinedNavigation));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}