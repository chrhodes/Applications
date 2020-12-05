using System.Collections.Generic;
using System.Threading.Tasks;
using AMLLinesEDMXCodeFirst;
using LineStatusViewer.Models;

namespace LineStatusViewer.Data
{
    public interface ILookupBuildsService
    {
        Task<IEnumerable<BuildItem>> GetBuildsAsync();
    }
}