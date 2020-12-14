using System;
using System.Data.Entity;

using VNC;

namespace PrismApp2.Persistence.Data
{
    public class PrismApp2DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp2DbContext>
    {
        protected override void Seed(PrismApp2DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
