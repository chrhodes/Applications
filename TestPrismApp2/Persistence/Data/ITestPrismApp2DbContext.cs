using System.Data.Entity;

using TestPrismApp2.Domain;

namespace TestPrismApp2.Persistence.Data
{
    public interface ITestPrismApp2DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
