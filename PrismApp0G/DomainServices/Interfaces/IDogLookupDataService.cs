using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace PrismApp0.DomainServices
{
    public interface IDogLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDogLookupAsync();
    }
}
