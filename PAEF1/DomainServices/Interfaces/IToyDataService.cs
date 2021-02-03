using System.Threading.Tasks;

using PAEF1.Domain;

using VNC.Core.DomainServices;

namespace PAEF1.DomainServices
{
    public interface IToyDataService : IGenericRepository<Toy>
    {
        Task<bool> IsReferencedByCatAsync(int id);
    }
}
