using System;
using System.Data.Entity;

namespace PrismApp2.Persistence.Data
{
    public class PrismApp2DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp2DbContext>
    {
        protected override void Seed(PrismApp2DbContext context)
        {
            Console.WriteLine("Seed(PrismApp2DbContext)");
            base.Seed(context);
        }
    }
}
