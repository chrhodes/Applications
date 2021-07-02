using System.Data.Entity;

using PAEF1a.Domain;

namespace PAEF1a.Persistence.Data
{
    public interface IPAEF1aDbContext
    {
        int SaveChanges();

        DbSet<Cat> CatsSet { get; set; }
    }
}
