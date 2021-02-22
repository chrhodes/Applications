using VNC.Core.DomainServices;

using WPFBinding101.Domain;

namespace WPFBinding101.DomainServices
{
    public interface IBirdDataService : IGenericRepository<Bird>
    {
        void RemovePhoneNumber(BirdPhoneNumber model);
    }
}
