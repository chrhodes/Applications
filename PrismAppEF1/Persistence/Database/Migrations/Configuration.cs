using System;
using System.Data.Entity.Migrations;

using VNC;

namespace PrismAppEF1.Persistence.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PrismAppEF1DbContext>
    {
        public Configuration()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            AutomaticMigrationsEnabled = true;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override void Seed(PrismAppEF1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            //  This method will be called after migrating to the latest version.

            SeedInitialDatabaseTables(context);
            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }

        void SeedInitialDatabaseTables(PrismAppEF1DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_APPNAME);

            //  Use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.BirdsSet.AddOrUpdate(
                i => i.Id,
                new Domain.Bird
                {
                    Id = 1,
                    FieldString = "Bird1",
                    FieldInt = 1,
                    FieldSingle = 1.1f,
                    FieldDouble = 11.11,
                    FieldDate = new DateTime(2001, 1, 1),
                    DateCreated = DateTime.Now
                },
                new Domain.Bird
                {
                    Id = 2,
                    FieldString = "Bird2",
                    FieldInt = 2,
                    FieldSingle = 2.2f,
                    FieldDouble = 22.22,
                    FieldDate = new DateTime(2002, 2, 2),
                    DateCreated = DateTime.Now
                },
                new Domain.Bird
                {
                    Id = 3,
                    FieldString = "Bird3",
                    FieldInt = 3,
                    FieldSingle = 3.3f,
                    FieldDouble = 33.33,
                    FieldDate = new DateTime(2003, 3, 3),
                    DateCreated = DateTime.Now
                });

            Log.PERSISTENCE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
