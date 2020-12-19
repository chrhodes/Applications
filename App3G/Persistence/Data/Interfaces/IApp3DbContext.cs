using System.Data.Entity;

using App3.Domain;

namespace App3.Persistence.Data
{
    public interface IApp3DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
