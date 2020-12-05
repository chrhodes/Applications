using System.Data.Entity;

namespace PrismApp1.Application.Interfaces
{
    public interface ILookupService<TEntity> where TEntity : class
    {
        IDbSet<TEntity> Items { get; set; }

        void Save();
    }
}
