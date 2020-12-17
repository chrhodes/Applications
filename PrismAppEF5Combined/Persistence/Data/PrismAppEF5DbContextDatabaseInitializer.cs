using System;
using System.Data.Entity;

using VNC;

namespace PrismAppEF5.Persistence.Data
{
    public class PrismAppEF5DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismAppEF5DbContext>
    {
        protected override void Seed(PrismAppEF5DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
