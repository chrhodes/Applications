using LineStatusViewer.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Infrastructure;
using LineStatusViewer.Data;
using LineStatusViewer.ViewModels;

namespace LineStatusViewer
{
    public class LineStatusViewerModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public LineStatusViewerModule(IUnityContainer container, IRegionManager regionManager)
        {
            try
            {
                // 09
                _container = container;
                _regionManager = regionManager;
            }
            catch (Exception ex)
            {
                var foo = ex;
            }
        }

        public void Initialize()
        {
            // 10
            RegisterViewsAndServices();

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusV, typeof(LineStatusView));
            // 12
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusG, typeof(LineStatusGridView));
            // 17
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusNVDV, typeof(LineStatusNVDVView));

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusNV, typeof(LineStatusNavigationView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusDV, typeof(LineStatusDetailView));

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusNV2, typeof(LineStatusNavigationView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionLineStatusDV2, typeof(LineStatusDetailView));
        }

        void RegisterViewsAndServices()
        {
            // 11
            _container.RegisterType<ILineStatusDataService, LineStatusDataService>();

            // TODO(crhodes)
            // Learn how to do the Autofac .AsImplementedInterfaces();

            _container.RegisterType<ILookupBuildsService, LookupDataService>();


            _container.RegisterType<ILineStatusNavigationViewModel, LineStatusNavigationViewModel>();
            _container.RegisterType<ILineStatusDetailViewModel, LineStatusDetailViewModel>();
        }
    }
}