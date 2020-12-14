using System;
using System.Data.Entity;

namespace PrismApp1.Persistence.Data
{
    public class PrismApp1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<PrismApp1DbContext>
    {
        protected override void Seed(PrismApp1DbContext context)
        {
            Console.WriteLine("Seed(PrismApp1DbContext)");
            base.Seed(context);
        }
    }
}
