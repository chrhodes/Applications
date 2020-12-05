using Prism.Ioc;
using Prism.Modularity;

using VNC;

namespace PrismApp1.DomainServices
{
    public class PrismApp1ServicesModule : IModule
    {
        IContainerProvider _containerProvider;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            _containerProvider = containerProvider;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Maybe this is where we register the CustomPoolAndSpaDbContext

            //throw new NotImplementedException();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
