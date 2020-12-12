using System;
using System.Data.Entity;

using VNC;

namespace PrismApp3.Persistence.Data
{
    public class PrismApp3DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp3DbContext>
    {
        protected override void Seed(PrismApp3DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
