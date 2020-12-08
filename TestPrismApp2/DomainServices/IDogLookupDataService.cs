using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace TestPrismApp2.DomainServices
{
    public interface IDogLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDogLookupAsync();
    }
}
