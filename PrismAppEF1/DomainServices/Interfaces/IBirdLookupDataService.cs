using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public interface IBirdLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBirdLookupAsync();
    }
}
