using EASECommandConsole.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Infrastructure;
using System.Windows.Controls;
using Prism.Regions;
using ModuleA;
using PeopleViewer;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.CSV;
using PersonRepository.SQL;
using LineStatusViewer;
using LineStatusBodyShopViewer;

namespace EASECommandConsole
{
    class Bootstrapper : UnityBootstrapper
    {
 
        // Step 1 - Configure the catalog of modules

        protected override void ConfigureModuleCatalog()
        {
            // 01
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;

            moduleCatalog.AddModule(typeof(ModuleAModule));
            moduleCatalog.AddModule(typeof(PeopleViewerDIModule));
            moduleCatalog.AddModule(typeof(PeopleViewerTightCouplingModule));
            moduleCatalog.AddModule(typeof(PeopleViewerLooseCouplingModule));
            moduleCatalog.AddModule(typeof(LineStatusViewerModule));
            moduleCatalog.AddModule(typeof(LineStatusBodyShopViewerModule));
            // 02
        }

        // Step 2 - Configure the container

        protected override void ConfigureContainer()
        {
            // 03
            base.ConfigureContainer();
            // Use the ServiceRepository
            //Container.RegisterType<PersonRepository.Interface.IPersonRepository, ServiceRepository>();
            // Use the CSVRepository
            //Container.RegisterType<PersonRepository.Interface.IPersonRepository, CSVRepository>();
            // Use the SQLRepository
            Container.RegisterType<PersonRepository.Interface.IPersonRepository, SQLRepository>();
            // 04
        }

        // Step 3 - Configure the RegionAdapters

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // 05
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
            // 06
        }

        // Step 4 - Create the Shell that will hold the modules in designated regions.

        protected override DependencyObject CreateShell()
        {
            // 07
            return Container.Resolve<MainWindow>();
        }

        // Step 5 - Show the MainWindow

        protected override void InitializeShell()
        {
            // 08
            Application.Current.MainWindow.Show();
        }
    }
}
