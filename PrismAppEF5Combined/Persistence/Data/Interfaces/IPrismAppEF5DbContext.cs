using System.Data.Entity;

using PrismAppEF5.Domain;

namespace PrismAppEF5.Persistence.Data
{
    public interface IPrismAppEF5DbContext
    {
        int SaveChanges();

        DbSet<Cat> CatSet { get; set; }
    }
}
