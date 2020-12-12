using System;
using System.Data.Entity;

using VNC;

namespace PrismApp0.Persistence.Data
{
    public class PrismApp0DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp0DbContext>
    {
        protected override void Seed(PrismApp0DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
