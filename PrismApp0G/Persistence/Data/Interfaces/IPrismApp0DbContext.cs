using System.Data.Entity;

using PrismApp0.Domain;

namespace PrismApp0.Persistence.Data
{
    public interface IPrismApp0DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
