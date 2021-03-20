using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF1.Animals.DomainServices
{
    public interface IBoneLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBoneLookupAsync();
    }
}
