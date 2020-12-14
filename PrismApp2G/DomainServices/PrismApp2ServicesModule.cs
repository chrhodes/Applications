using System;

using Prism.Ioc;
using Prism.Modularity;

using VNC;

namespace PrismApp2.DomainServices
{
    public class PrismApp2ServicesModule : IModule
    {
        IContainerProvider _containerProvider;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _containerProvider = containerProvider;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            // TODO(crhodes)
            // Maybe this is where we register the CustomPoolAndSpaDbContext

            //throw new NotImplementedException();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
