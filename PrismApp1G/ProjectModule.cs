using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismApp1.Core;
using PrismApp1.DomainServices;
using PrismApp1.Presentation.ViewModels;
using PrismApp1.Presentation.Views;

using Unity;

using VNC;

namespace PrismApp1
{
    public class ProjectModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public ProjectModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //_container = container;
            _regionManager = regionManager;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            containerRegistry.Register<IProjectMainViewModel, ProjectMainViewModel>();
            containerRegistry.Register<IProjectMain, ProjectMain>();

            //containerRegistry.RegisterSingleton<INavigationViewModel, NavigationViewModel>();
            containerRegistry.RegisterSingleton<INavigation, ProjectNavigation>();

            containerRegistry.Register<IProjectDetailViewModel, ProjectDetailViewModel>();
            containerRegistry.Register<IProjectDetail, ProjectDetail>();

            //containerRegistry.RegisterSingleton<IProjectDataService, ProjectDataService>();
            //containerRegistry.RegisterSingleton<IProjectLookupDataService, ProjectLookupDataService>();

            containerRegistry.Register<IProjectDataService, ProjectDataService>();
            containerRegistry.Register<IProjectLookupDataService, ProjectLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //this loads ProjectMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.ProjectMainRegion, typeof(ProjectMain));

            // These load into ProjectMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.ProjectNavigationRegion, typeof(ProjectNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.ProjectDetailRegion, typeof(ProjectDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}