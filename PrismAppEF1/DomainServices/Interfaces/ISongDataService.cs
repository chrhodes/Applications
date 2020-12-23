using System.Threading.Tasks;

using PrismAppEF1.Domain;

using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public interface ISongDataService : IGenericRepository<Song>
    {
        Task<bool> IsReferencedByBirdAsync(int id);
    }
}
