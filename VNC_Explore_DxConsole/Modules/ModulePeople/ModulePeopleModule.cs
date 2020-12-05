using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using VNCExploreConsole.Infrastructure;
using ModuleInterfaces;

namespace ModulePeople
{
    public class PeopleModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            //// This is for single content not tab view

            //var vm = _container.Resolve<IPersonViewModel>();
            //_regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);

            //// This is for TabControl multiple view 

            //IRegion region = _regionManager.Regions[RegionNames.ContentRegion];

            //var vm = _container.Resolve<IPersonViewModel>();
            //vm.CreatePerson("Bob", "Smith");

            //region.Add(vm.View);
            //region.Activate(vm.View);

            //var vm2 = _container.Resolve<IPersonViewModel>();
            //vm2.CreatePerson("Karl", "Sums");
            //region.Add(vm2.View);

            //var vm3 = _container.Resolve<IPersonViewModel>();
            //vm3.CreatePerson("Jeff", "Lock");
            //region.Add(vm3.View);

            // This is for RegionContext People and Person Detail view

            var vm = _container.Resolve<IPeopleViewModel>();
            _regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);

            _regionManager.RegisterViewWithRegion("PersonDetailsRegion", typeof(PersonDetails));
        }

        protected void RegisterViewsAndServices()
        {
            //// This is for Persons

            //_container.RegisterType<IPersonViewModel, PersonViewModel>();
            //_container.RegisterType<IPersonView, PersonView>();

            // This is for People

            _container.RegisterType<IPeopleViewModel, PeopleViewModel>();
            _container.RegisterType<IPeople, People>();
            _container.RegisterType<IPersonDetails, PersonDetails>();
            _container.RegisterType<IPersonDetailsViewModel, PersonDetailsViewModel>();
        }
    }
}