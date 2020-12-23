using System.Data.Entity;

using PrismAppEF1.Domain;

namespace PrismAppEF1.Persistence.Data
{
    public interface IPrismAppEF1DbContext
    {
        int SaveChanges();

        DbSet<Bird> BirdsSet { get; set; }
    }
}
