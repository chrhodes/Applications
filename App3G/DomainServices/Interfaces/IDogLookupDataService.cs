using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace App3.DomainServices
{
    public interface IDogLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDogLookupAsync();
    }
}
