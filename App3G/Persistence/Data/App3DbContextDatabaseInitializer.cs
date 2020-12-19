using System;
using System.Data.Entity;

using VNC;

namespace App3.Persistence.Data
{
    public class App3DbContextDatabaseInitializer : CreateDatabaseIfNotExists<App3DbContext>
    {
        protected override void Seed(App3DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
