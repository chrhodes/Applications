using System;
using System.Data.Entity;

namespace TestPrismApp1.Persistence.Data
{
    public class TestPrismApp1DbContextDatabaseInitializer : CreateDatabaseIfNotExists<TestPrismApp1DbContext>
    {
        protected override void Seed(TestPrismApp1DbContext context)
        {
            Console.WriteLine("Seed(TestPrismApp1DbContext)");
            base.Seed(context);
        }
    }
}
