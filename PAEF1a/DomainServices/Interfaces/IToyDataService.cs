using System.Threading.Tasks;

using PAEF1a.Domain;

using VNC.Core.DomainServices;

namespace PAEF1a.DomainServices
{
    public interface IToyDataService : IGenericRepository<Toy>
    {
        Task<bool> IsReferencedByCatAsync(int id);
    }
}
