using System;
using System.Data.Entity;

using VNC;

namespace PrismApp1.Persistence.Data
{
    public class PrismApp1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp1DbContext>
    {
        protected override void Seed(PrismApp1DbContext context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            Console.WriteLine("Seed(PrismApp1DbContext)");
            base.Seed(context);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
