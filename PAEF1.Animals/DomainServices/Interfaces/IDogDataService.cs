using PAEF1.Animals.Domain;

using VNC.Core.DomainServices;

namespace PAEF1.Animals.DomainServices
{
    public interface IDogDataService : IGenericRepository<Dog>
    {
        void RemovePhoneNumber(DogPhoneNumber model);
    }
}
