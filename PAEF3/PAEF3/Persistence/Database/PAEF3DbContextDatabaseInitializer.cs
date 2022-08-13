using System;
using System.Data.Entity;

using VNC;

namespace PAEF3.Persistence.Data
{
    public class PAEF3DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PAEF3DbContext>
    {
        protected override void Seed(PAEF3DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
