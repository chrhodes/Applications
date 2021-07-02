using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF1a.DomainServices
{
    public interface IToyLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetToyLookupAsync();
    }
}
