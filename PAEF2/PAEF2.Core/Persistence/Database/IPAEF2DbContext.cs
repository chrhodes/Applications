using System.Data.Entity;

using PAEF2.Domain;

namespace PAEF2.Persistence.Data
{
    public interface IPAEF2DbContext
    {
        int SaveChanges();

        DbSet<Car> CarsSet { get; set; }
    }
}
