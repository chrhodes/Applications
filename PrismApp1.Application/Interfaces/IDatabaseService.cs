using System.Data.Entity;

using Common.Domain;

using PrismApp1.Domain;

namespace PrismApp1.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Cat> Cat { get; set; }

        void Save();
    }
}
