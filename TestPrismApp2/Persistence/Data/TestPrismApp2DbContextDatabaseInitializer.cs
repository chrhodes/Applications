using System;
using System.Data.Entity;

namespace TestPrismApp2.Persistence.Data
{
    public class TestPrismApp2DbContextDatabaseInitializer : CreateDatabaseIfNotExists<TestPrismApp2DbContext>
    {
        protected override void Seed(TestPrismApp2DbContext context)
        {
            Console.WriteLine("Seed(TestPrismApp2DbContext)");
            base.Seed(context);
        }
    }
}
