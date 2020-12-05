using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using PrismApp1.Domain;

using VNC;

namespace PrismApp1.Persistence.Data
{
    public class DatabaseService : DbContext, IPrismApp1DbContext
    {
        public DbSet<Cat> CatSet { get; set; }

        public DatabaseService() : base("PrismApp1DB")
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            //Database.SetInitializer(new DatabaseInitializer());
            Database.SetInitializer<PrismApp1DbContext>(
                new DropCreateDatabaseIfModelChanges<PrismApp1DbContext>());

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            try
            {
                // TODO(crhodes)
                // This gives us too many types including the embedded ServiceType and PoolConditionReport
                // Need some way of filtering them out, otherwise have to put pointless IsDirty field in them.

                modelBuilder.Types()
                    .Configure(c => c.Ignore("IsDirty"));

            }
            catch (InvalidOperationException ex)
            {
                // Ignore
            }

            base.OnModelCreating(modelBuilder);

            // Do not pluralize table names

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Save()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            this.SaveChanges();

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
