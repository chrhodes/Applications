using System.Data.Entity;

using WPFBinding101.Domain;

namespace WPFBinding101.Persistence.Data
{
    public interface IWPFBinding101DbContext
    {
        int SaveChanges();

        DbSet<Bird> BirdsSet { get; set; }
    }
}
