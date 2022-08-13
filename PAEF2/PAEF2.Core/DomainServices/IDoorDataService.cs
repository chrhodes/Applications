using System.Threading.Tasks;

using PAEF2.Domain;

using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public interface IDoorDataService : IGenericRepository<Door>
    {
        Task<bool> IsReferencedByCarAsync(int id);
    }
}
