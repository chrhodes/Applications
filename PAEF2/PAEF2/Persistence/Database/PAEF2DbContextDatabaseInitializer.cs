using System;
using System.Data.Entity;

using VNC;

namespace PAEF2.Persistence.Data
{
    public class PAEF2DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PAEF2DbContext>
    {
        protected override void Seed(PAEF2DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
