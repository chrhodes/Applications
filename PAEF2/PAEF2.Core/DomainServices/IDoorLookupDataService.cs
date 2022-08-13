using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public interface IDoorLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDoorLookupAsync();
    }
}
