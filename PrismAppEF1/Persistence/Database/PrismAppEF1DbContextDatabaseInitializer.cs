using System;
using System.Data.Entity;

using VNC;

namespace PrismAppEF1.Persistence.Data
{
    public class PrismAppEF1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismAppEF1DbContext>
    {
        protected override void Seed(PrismAppEF1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
