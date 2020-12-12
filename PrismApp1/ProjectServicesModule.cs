using System;

using Prism.Ioc;
using Prism.Modularity;

using VNC;

namespace PrismApp1.DomainServices
{
    public class ProjectServicesModule : IModule
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


            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
