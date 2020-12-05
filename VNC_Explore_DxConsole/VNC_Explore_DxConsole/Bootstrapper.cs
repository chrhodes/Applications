using VNC_Explore_DxConsole.Views;
using System.Windows;
using Prism.Modularity;
using Prism.Unity;
using System.Windows.Controls;
using Prism.Regions;
using ModuleA;

using System;

using VNC.Core.Mvvm.Prism;

namespace VNC_Explore_DxConsole
{
    class Bootstrapper : UnityBootstrapper
    {
        // Step 1a - Create the catalog of Modules
        //
        // This is called when you do not directly reference the Assembly
        // containing the module.

        // TODO(crhodes)
        // Figure out how you can do more than one of these creates at a time
        // e.g. App.Config and look in Directory

        // To load modules from directory
        //
        // NB. ModuleB.dll and ModuleD.dll have not been referenced
        // but appears in .\bin\Modules folder

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //}

        // To load modules from Xaml
        //
        // NB. ModuleC.dll has not been referenced
        // but appear in .\bin folder

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return Prism.Modularity.ModuleCatalog.CreateFromXaml(
        //        new Uri("/VNC_Explore_DxConsole;component/XamlCatalog.xaml", UriKind.Relative));
        //}

        // To load from an App.Config file
        //
        // NB. ModuleD.dll has not been referenced
        // but appears in .\bin\Modules folder

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        // Step 1b - Configure the catalog of modules
        // Modules are loaded at Startup and must be a project reference

        protected override void ConfigureModuleCatalog()
        {
            Type moduleAType = typeof(ModuleAModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleAType.Name,
                ModuleType = moduleAType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
                //    InitializationMode = InitializationMode.OnDemand
            });

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;

            //moduleCatalog.AddModule(typeof(ModuleAModule));

            // View Examples

            //moduleCatalog.AddModule(typeof(ModuleSimpleViewModule));

            //moduleCatalog.AddModule(typeof(ModuleMVVMView1stModule));

            //moduleCatalog.AddModule(typeof(ModuleMVVMViewModel1stModule));

            // Commanding Examples

            // By default Prism uses just the class name to distinguish modules
            // Even though these are from different namespaces they collide

            //AddModuleToCatalog(typeof(StatusBar.ModuleStatusBarModule), moduleCatalog);
            //AddModuleToCatalog(typeof(StatusBarEA.StatusBarModule), moduleCatalog);

            //moduleCatalog.AddModule(typeof(PeopleDC.PeopleModule));
            //moduleCatalog.AddModule(typeof(PeopleCC.PeopleModule));

            //AddModuleToCatalog(typeof(ModulePeopleDC.ModulePeopleModule), moduleCatalog);
            //AddModuleToCatalog(typeof(ModulePeopleCC.ModulePeopleModule), moduleCatalog);

            //moduleCatalog.AddModule(typeof(ModuleToolbarModule));

            //moduleCatalog.AddModule(typeof(ModulePeopleViewerDIModule));
            //moduleCatalog.AddModule(typeof(ModulePeopleViewerTightCouplingModule));
            //moduleCatalog.AddModule(typeof(ModulePeopleViewerLooseCouplingModule));
        }

        void AddModuleToCatalog(Type moduleType, ModuleCatalog catalog)
        {
            ModuleInfo moduleInfo = new ModuleInfo();

            // Use the fully qualified name to distinguish the ModuleName
            moduleInfo.ModuleName = moduleType.AssemblyQualifiedName;
            moduleInfo.ModuleType = moduleType.AssemblyQualifiedName;

            catalog.AddModule(moduleInfo);
        }
        // Step 2 - Configure the container

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            // Use the ServiceRepository
            //Container.RegisterType<PersonRepository.Interface.IPersonRepository, ServiceRepository>();
            // Use the CSVRepository
            //Container.RegisterType<PersonRepository.Interface.IPersonRepository, CSVRepository>();
            // Use the SQLRepository
            //Container.RegisterType<PersonRepository.Interface.IPersonRepository, SQLRepository>();
        }

        // Step 3 - Configure the RegionAdapters if any custom ones have been created

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

            //mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }

        // Step 4 - Create the Shell that will hold the modules in designated regions.

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        // Step 5 - Show the MainWindow

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
