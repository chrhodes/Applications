using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.Domain;

namespace PrismApp1.DomainServices
{
    public interface ICatLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCatLookupAsync();
    }
}
