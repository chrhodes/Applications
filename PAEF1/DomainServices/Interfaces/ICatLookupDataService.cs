using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF1.DomainServices
{
    public interface ICatLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCatLookupAsync();
    }
}
