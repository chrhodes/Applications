using System;
using System.Data.Entity;

using VNC;

namespace PAI1.Persistence.Data
{
    public class PAI1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PAI1DbContext>
    {
        protected override void Seed(PAI1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
