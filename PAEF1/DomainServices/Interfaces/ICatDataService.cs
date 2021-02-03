using PAEF1.Domain;

using VNC.Core.DomainServices;

namespace PAEF1.DomainServices
{
    public interface ICatDataService : IGenericRepository<Cat>
    {
        void RemovePhoneNumber(CatPhoneNumber model);
    }
}
