//using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Prism.Regions;
using Prism.Unity;
using VNC.Core.Mvvm.Prism;
using VNCExploreConsole.Infrastructure;

namespace ModuleB1
{
    public class ModuleB1Module : ModuleBase
    {
        public ModuleB1Module(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolBarRegion, typeof(ViewB1Button));

            // This is for the navigation demo
            ApplicationCommands.NavigateCommand.Execute(typeof(ViewB1));
        }

        protected override void RegisterTypes()
        {
            // Cannot do this - Shows up as System.Object
            //Container.RegisterType<ViewB1>();

            // When using Navigation have to register as Object.
            //Container.RegisterType<object, ViewA1>(typeof(ViewB1).FullName);

            // This hides the complexity.
            Container.RegisterTypeForNavigation<ViewB1>();

            Container.RegisterType<IViewB1ViewModel, ViewB1ViewModel>();

            // This is for the parameters demo

            Container.RegisterType<IEmailViewModel, EmailViewModel>();
            Container.RegisterTypeForNavigation<Email>();
        }
    }
}
