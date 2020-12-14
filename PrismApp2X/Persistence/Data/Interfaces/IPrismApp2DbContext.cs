using System.Data.Entity;

using PrismApp2.Domain;

namespace PrismApp2.Persistence.Data
{
    public interface IPrismApp2DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
