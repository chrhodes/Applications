using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public interface ICarLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCarLookupAsync();
    }
}
