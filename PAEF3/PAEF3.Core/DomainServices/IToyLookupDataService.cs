using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PAEF3.DomainServices
{
    public interface IToyLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetToyLookupAsync();
    }
}
