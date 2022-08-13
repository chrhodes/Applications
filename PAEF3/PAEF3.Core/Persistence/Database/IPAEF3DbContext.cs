using System.Data.Entity;

using PAEF3.Domain;

namespace PAEF3.Persistence.Data
{
    public interface IPAEF3DbContext
    {
        int SaveChanges();

        DbSet<Cat> CatsSet { get; set; }
    }
}
