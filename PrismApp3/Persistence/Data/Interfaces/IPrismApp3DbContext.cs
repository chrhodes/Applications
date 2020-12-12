using System.Data.Entity;

using PrismApp3.Domain;

namespace PrismApp3.Persistence.Data
{
    public interface IPrismApp3DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
