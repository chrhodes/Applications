using System.Threading.Tasks;

using PAI1.Domain;

using VNC.Core.DomainServices;

namespace PAI1.DomainServices
{
    public interface IFoodDataService : IGenericRepository<Food>
    {
        Task<bool> IsReferencedByDogAsync(int id);
    }
}
