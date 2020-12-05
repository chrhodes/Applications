using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using PrismApp1.Core;
using PrismApp1.Presentation.Views;
using PrismApp1.DomainServices;
using VNC;
using System;
//using PrismApp1.DomainServices;

namespace PrismApp1.Presentation
{
    public class CatModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public CatModule(IUnityContainer container, IRegionManager regionManager)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            _container = container;
            _regionManager = regionManager;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Should we be registering stuff here and not in App.Xaml.cs
            //_container.RegisterType<ViewModels.ICatDetailViewModel, ViewModels.CatDetailViewModel>();
            //_container.RegisterType<Views.ICatDetail, Views.CatDetail>();

            // TODO(crhodes)
            // Uncomment this when ready to pull in data


            _container.RegisterType<ICatDataService, CatDataService>();
            _container.RegisterType<ICatLookupDataService, CatLookupDataService>();

            _container.RegisterType<ViewModels.ICatViewModel, ViewModels.CatViewModel>();
            _container.RegisterType<Views.ICat, Views.Cat>();

            //_container.RegisterType<IDogLookupDataService, DogLookupDataService>();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            //_regionManager.RegisterViewWithRegion(RegionNames.CatRegion, typeof(Views.Cat));
            _regionManager.RegisterViewWithRegion(RegionNames.CatRegion, typeof(ICat));
            //_regionManager.RegisterViewWithRegion(RegionNames.CatDetailRegion, typeof(Views.CatDetail));

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}