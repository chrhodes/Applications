using PAEF2.Domain;

using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public interface ICarDataService : IGenericRepository<Car>
    {
        void RemovePhoneNumber(CarPhoneNumber model);
    }
}
