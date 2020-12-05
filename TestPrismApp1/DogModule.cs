using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using TestPrismApp1.Core;
using TestPrismApp1.DomainServices;

using Unity;

using VNC;
using VNC.Core.Services;

namespace TestPrismApp1
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
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            containerRegistry.Register<Presentation.ViewModels.IDogDetailViewModel, Presentation.ViewModels.DogDetailViewModel>();
            containerRegistry.Register<Presentation.Views.IDogDetail, Presentation.Views.DogDetail>();

            containerRegistry.Register<IDogDataService, DogDataService>();

            containerRegistry.Register<Presentation.ViewModels.IDogViewModel, Presentation.ViewModels.DogViewModel>();
            containerRegistry.Register<Presentation.Views.IDog, Presentation.Views.Dog>();

            containerRegistry.Register<IDogLookupDataService, LookupDataService>();

            containerRegistry.Register<IMessageDialogService, MessageDialogService>();
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _regionManager.RegisterViewWithRegion(RegionNames.DogRegion, typeof(Presentation.Views.Dog));
            _regionManager.RegisterViewWithRegion(RegionNames.DogDetailRegion, typeof(Presentation.Views.DogDetail));
        }
    }
}