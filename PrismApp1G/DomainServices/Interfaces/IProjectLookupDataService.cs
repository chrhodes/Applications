using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PrismApp1.DomainServices
{
    public interface IProjectLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetProjectLookupAsync();
    }
}
