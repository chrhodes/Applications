using System.Data.Entity;

using PrismEFI2.Domain;

namespace PrismEFI2.Persistence.Data
{
    public interface IPrismEFI2DbContext
    {
        int SaveChanges();

        DbSet<Dog> DogSet { get; set; }
    }
}
