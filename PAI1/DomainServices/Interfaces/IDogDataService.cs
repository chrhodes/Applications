using PAI1.Domain;

using VNC.Core.DomainServices;

namespace PAI1.DomainServices
{
    public interface IDogDataService : IGenericRepository<Dog>
    {
        void RemovePhoneNumber(DogPhoneNumber model);
    }
}
