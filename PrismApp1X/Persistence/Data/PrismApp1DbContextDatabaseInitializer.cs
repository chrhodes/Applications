using System;
using System.Data.Entity;

using VNC;

namespace PrismApp1.Persistence.Data
{
    public class PrismApp1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp1DbContext>
    {
        protected override void Seed(PrismApp1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
