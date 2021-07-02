using System;
using System.Data.Entity;

using VNC;

namespace PAEF1a.Persistence.Data
{
    public class PAEF1aDbContextDatabaseInitializer : CreateDatabaseIfNotExists<PAEF1aDbContext>
    {
        protected override void Seed(PAEF1aDbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
