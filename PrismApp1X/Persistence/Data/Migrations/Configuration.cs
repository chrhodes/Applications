using System;
using System.Data.Entity.Migrations;

using VNC;

namespace PrismApp1.Persistence.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PrismApp1DbContext>
    {
        public Configuration()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            AutomaticMigrationsEnabled = false;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override void Seed(PrismApp1DbContext context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            Console.WriteLine("Seed()");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // This Seeds Address, Customer, and Material

            SeedInitialDatabaseTables(context);
            base.Seed(context);

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        void SeedInitialDatabaseTables(PrismApp1DbContext context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            context.CatSet.AddOrUpdate(
                i => i.Id,
                new Domain.Cat
                {
                    Id = 1,
                    FieldString = "String1",
                    FieldInt = 41,
                    FieldDouble = 41.41
                },
                new Domain.Cat
                {
                    Id = 2,
                    FieldString = "String2",
                    FieldInt = 42,
                    FieldDouble = 42.42
                });

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
