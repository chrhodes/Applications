using System.Data.Entity;

using PrismApp1.Domain;

namespace PrismApp1.Persistence.Data
{
    public interface IPrismApp1DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
