using System.Data.Entity;

using TestPrismApp1.Domain;

namespace TestPrismApp1.Persistence.Data
{
    public interface ITestPrismApp1DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
