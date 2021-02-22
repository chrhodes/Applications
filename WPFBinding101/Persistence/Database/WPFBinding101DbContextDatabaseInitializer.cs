using System;
using System.Data.Entity;

using VNC;

namespace WPFBinding101.Persistence.Data
{
    public class WPFBinding101DbContextDatabaseInitializer : CreateDatabaseIfNotExists<WPFBinding101DbContext>
    {
        protected override void Seed(WPFBinding101DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
