using System;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Prism.Regions;
using VNCExploreConsole.Infrastructure;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using ModuleInterfaces;

namespace ModuleMVVMViewModel1st
{
    public class ModuleMVVMViewModel1stModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        // Need a container so we can register our views
        // and a RegionManager so we can compose views and perform View discovery.
        // Prism will pass in when this module is created.

        public ModuleMVVMViewModel1stModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _regionManager = manager;
        }

        public void Initialize()
        {
            // 1. Register Views and ViewModels

            // ViewModel first approach.

            // ViewModel is responsible for instantiating the View
            // When container creates ViewModel is sees a View is required in constructor.
            // Container resolves the View and passes it into the ViewModel's constructor.

            // Register a View as type IContentA_VM1_View.  Container will return ContentA_VM1
            // because ContentA_VM1 implements IContentA_VM1_View
            // Do same for IContentA_VM1_ViewViewModel, ContentA_VM1_ViewViewModel

            _container.RegisterType<ToolbarA>();
            _container.RegisterType<IContentA, ContentA_VM1>();
            _container.RegisterType<IContentAViewModel, ContentA_VM1_ViewModel>();

            // 2. Compose Application views using registered Views and ViewModels

            // Enable view discovery for toolbar
            // Not clear if need to RegisterType with container, supra, if using region manager

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegionV_VM1, typeof(ToolbarA));

            // Enable view discovery for content

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegionVM1, typeof(ContentA_VM1));

            // Problem here is we get the View but no ViewModel
            //    Can see this if uncomment TextBlock in Xaml with Text="..."
            //    and comment out TextBlock with Binding
            // Because View does not know about ViewModel.

            // Enable view Injection

            var vm1 = _container.Resolve<IContentAViewModel>();
            vm1.Message = "Prism Rocks! First View";

            ////Now inject in a region the view that viewmodel created. (16)
            //_regionManager.Regions[RegionNames.ContentRegionVM1].Add(vm1.View);

            //// If don't deactivate first view the second view is covered up.

            ////_regionManager.Regions[RegionNames.ContentRegionVM1].Deactivate(vm1.View);

            var vm2 = _container.Resolve<IContentAViewModel>();
            vm2.Message = "Prism Rocks! Second ViewModel";

            //_regionManager.Regions[RegionNames.ContentRegionVM1].Add(vm2.View);

            // If you need more control of region,

            try
            {
                IRegion region = _regionManager.Regions[RegionNames.ContentRegionV_VM1];
                // Can get list of Views, ActiveViews, Activate, Deactivate, Add, Remove, Activate, Deactivate, etc.
                region.Add(vm1.View);
                // If don't uncomment next line, still see first view
                //region.Deactivate(vm1.View);
                region.Add(vm2.View);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
