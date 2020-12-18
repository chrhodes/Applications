using System;
using System.Data.Entity;

using VNC;

namespace PrismEFI2.Persistence.Data
{
    public class PrismEFI2DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismEFI2DbContext>
    {
        protected override void Seed(PrismEFI2DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
