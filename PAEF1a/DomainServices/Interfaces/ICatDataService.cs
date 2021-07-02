using PAEF1a.Domain;

using VNC.Core.DomainServices;

namespace PAEF1a.DomainServices
{
    public interface ICatDataService : IGenericRepository<Cat>
    {
        void RemovePhoneNumber(CatPhoneNumber model);
    }
}
