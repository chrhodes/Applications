using System.Threading.Tasks;

using VNC.Core.DomainServices;

using WPFBinding101.Domain;

namespace WPFBinding101.DomainServices
{
    public interface ISeedDataService : IGenericRepository<Seed>
    {
        Task<bool> IsReferencedByBirdAsync(int id);
    }
}
