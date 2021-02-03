using System.Data.Entity;

using PAEF1.Domain;

namespace PAEF1.Persistence.Data
{
    public interface IPAEF1DbContext
    {
        int SaveChanges();

        DbSet<Cat> CatsSet { get; set; }
    }
}
