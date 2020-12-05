namespace PrismApp1.Migrations
{
    using System.Data.Entity.Migrations;

    using VNC;

    internal sealed class Configuration : DbMigrationsConfiguration<PrismApp1.Persistence.Data.PrismApp1DbContext>
    {
        public Configuration()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            AutomaticMigrationsEnabled = false;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override void Seed(PrismApp1.Persistence.Data.PrismApp1DbContext context)
        {

            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
