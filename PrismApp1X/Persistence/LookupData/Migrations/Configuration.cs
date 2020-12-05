using System.Data.Entity.Migrations;

using VNC;

namespace PrismApp1.Persistence.LookupData.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PrismApp1.Persistence.LookupData.PrismApp1LookupsDbContext>
    {
        public Configuration()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            AutomaticMigrationsEnabled = false;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override void Seed(PrismApp1.Persistence.LookupData.PrismApp1LookupsDbContext context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
