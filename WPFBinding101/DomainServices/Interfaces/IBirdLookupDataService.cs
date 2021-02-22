using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace WPFBinding101.DomainServices
{
    public interface IBirdLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBirdLookupAsync();
    }
}
