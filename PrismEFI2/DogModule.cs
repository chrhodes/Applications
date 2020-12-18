using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismEFI2.Core;
using PrismEFI2.DomainServices;
using PrismEFI2.Presentation.ViewModels;
using PrismEFI2.Presentation.Views;

using Unity;

using VNC;

namespace PrismEFI2
{
    public class DogModule : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public DogModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<IDogMainViewModel, DogMainViewModel>();
            containerRegistry.Register<IDogMain, DogMain>();

            containerRegistry.RegisterSingleton<IDogNavigationViewModel, DogNavigationViewModel>();
            containerRegistry.RegisterSingleton<IDogNavigation, DogNavigation>();

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

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)

            //this loads DogMain into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.DogMainRegion, typeof(IDogMain));

            // These load into DogMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.DogNavigationRegion, typeof(IDogNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(IDogDetail));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}