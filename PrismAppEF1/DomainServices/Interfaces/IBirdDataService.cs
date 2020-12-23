using PrismAppEF1.Domain;

using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public interface IBirdDataService : IGenericRepository<Bird>
    {
        void RemovePhoneNumber(BirdPhoneNumber model);
    }
}
