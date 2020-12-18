using System.Threading.Tasks;

using PrismEFI2.Domain;

using VNC.Core.DomainServices;

namespace PrismEFI2.DomainServices.Interfaces
{
    public interface IFoodRepository : IConnectedRepository<Food>
    {
        Task<bool> IsReferencedByDogAsync(int foodId);
    }
}
