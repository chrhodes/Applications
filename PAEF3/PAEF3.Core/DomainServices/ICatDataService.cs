using PAEF3.Domain;

using VNC.Core.DomainServices;

namespace PAEF3.DomainServices
{
    public interface ICatDataService : IGenericRepository<Cat>
    {
        void RemovePhoneNumber(CatPhoneNumber model);
    }
}
