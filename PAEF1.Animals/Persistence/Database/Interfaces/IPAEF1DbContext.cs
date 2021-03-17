using System.Data.Entity;

using PAEF1.Animals.Domain;

namespace PAEF1.Animals.Persistence.Data
{
    public interface IPAEF1DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogsSet { get; set; }
    }
}
