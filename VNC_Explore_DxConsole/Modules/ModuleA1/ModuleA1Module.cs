using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;
using VNC.Core.Mvvm.Prism;
using VNCExploreConsole.Infrastructure;

namespace ModuleA1
{
    public class ModuleA1Module : ModuleBase
    {
        public ModuleA1Module(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolBarRegion, typeof(ViewA1Button));

            // This is for the navigation demo
            ApplicationCommands.NavigateCommand.Execute(typeof(ViewA1));
        }

        protected override void RegisterTypes()
        {
            // Cannot do this - Shows up as System.Object
            //Container.RegisterType<ViewA1>();

            // When using Navigation have to register as Object.
            //Container.RegisterType<object, ViewA1>(typeof(ViewA1).FullName);

            // This hides the complexity.
            Container.RegisterTypeForNavigation<ViewA1>();

            Container.RegisterType<IViewA1ViewModel, ViewA1ViewModel > ();

            // This is for the parameters demo

            Container.RegisterType<IEmailViewModel, EmailViewModel>();
            Container.RegisterTypeForNavigation<Email>();
        }
    }
}
