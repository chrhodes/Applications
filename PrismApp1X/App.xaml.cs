using System.Windows;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Regions;

using PrismApp1.DomainServices;
using PrismApp1.Presentation.Views;

using PrismApp1.Presentation;
using System;
using VNC;

namespace PrismApp1
{
    public partial class App : PrismApplication
    {
        // 01

        protected override void ConfigureViewModelLocator()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.ConfigureViewModelLocator();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        protected override IContainerExtension CreateContainerExtension()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);
            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

            return base.CreateContainerExtension();
        }

        // 03 - Create the catalog of Modules

        protected override IModuleCatalog CreateModuleCatalog()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);
            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

            return base.CreateModuleCatalog();
        }

        // 04

        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.RegisterRequiredTypes(containerRegistry);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 05

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);
            //containerRegistry.RegisterSingleton<ICustomerDataService, CustomerDataServiceMock>();
            //containerRegistry.RegisterSingleton<IMaterialDataService, MaterialDataServiceMock>();

            // TODO(crhodes)
            // Think this is where we switch to using the Generic Repository.
            // But how to avoid pulling knowledge of EF Context in.  Maybe Service hides details
            // of 
            //containerRegistry.RegisterSingleton<IAddressDataService, AddressDataService>();
            // AddressDataService2 has a constructor that takes a CustomPoolAndSpaDbContext.

            //containerRegistry.RegisterSingleton<ICatDataService, CatDataService>();
            //containerRegistry.RegisterSingleton<ICatLookupDataService, CatLookupDataService>();

            // Add the new UI elements
            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 06

        protected override void ConfigureServiceLocator()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.ConfigureServiceLocator();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 07 - Configure the catalog of modules
        // Modules are loaded at Startup and must be a project reference

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            moduleCatalog.AddModule(typeof(CatModule));
            //moduleCatalog.AddModule(typeof(CustomPoolAndSpaServicesModule));
            //moduleCatalog.AddModule(typeof(Module));

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 08

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 09

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 10

        protected override void RegisterFrameworkExceptionTypes()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.RegisterFrameworkExceptionTypes();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 11 

        protected override Window CreateShell()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);
            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

            return Container.Resolve<MainWindowDx>();
        }

        // 12

        protected override void InitializeShell(Window shell)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.InitializeShell(shell);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        // 13 

        protected override void InitializeModules()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            base.InitializeModules();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            Log.Debug($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            Log.Debug($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            Log.Debug($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void Application_Deactivated(object sender, System.EventArgs e)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            Log.Debug($"Exit", Common.LOG_APPNAME, startTicks);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            long startTicks = Log.Info("Enter", Common.LOG_APPNAME);

            MessageBox.Show("Application_DispatcherUnhandledException: " + e.Exception.Message, Common.LOG_APPNAME, MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Application_DispatcherUnhandledException Inner: " + e.Exception.InnerException.Message, Common.LOG_APPNAME, MessageBoxButton.OK, MessageBoxImage.Warning);

            //e.Handled = true;   // Use if can handle exception that is thrown
            e.Handled = false;  // Default

            Log.Info($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
