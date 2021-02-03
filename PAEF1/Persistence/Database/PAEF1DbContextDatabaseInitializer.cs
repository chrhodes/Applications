using System;
using System.Data.Entity;

using VNC;

namespace PAEF1.Persistence.Data
{
    public class PAEF1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PAEF1DbContext>
    {
        protected override void Seed(PAEF1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
