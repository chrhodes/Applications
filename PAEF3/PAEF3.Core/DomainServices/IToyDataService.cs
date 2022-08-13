using System.Threading.Tasks;

using PAEF3.Domain;

using VNC.Core.DomainServices;

namespace PAEF3.DomainServices
{
    public interface IToyDataService : IGenericRepository<Toy>
    {
        Task<bool> IsReferencedByCatAsync(int id);
    }
}
