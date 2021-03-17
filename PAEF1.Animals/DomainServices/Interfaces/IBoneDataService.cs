using System.Threading.Tasks;

using PAEF1.Animals.Domain;

using VNC.Core.DomainServices;

namespace PAEF1.Animals.DomainServices
{
    public interface IBoneDataService : IGenericRepository<Bone>
    {
        Task<bool> IsReferencedByDogAsync(int id);
    }
}
