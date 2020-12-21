using System.Data.Entity;

using PAI1.Domain;

namespace PAI1.Persistence.Data
{
    public interface IPAI1DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogsSet { get; set; }
    }
}
