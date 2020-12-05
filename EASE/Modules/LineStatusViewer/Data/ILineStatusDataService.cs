using System.Collections.Generic;
using System.Threading.Tasks;
using AMLLinesEDMXCodeFirst;
using LineStatusViewer.Models;

namespace LineStatusViewer.Data
{
    public interface ILineStatusDataService
    {
        IEnumerable<AML_LineStatus> GetAll();

        Task<IEnumerable<AML_LineStatus>> GetAllAsync();

        Task<AML_LineStatus> GetByBuildItemAsync(BuildItem buildItem);
        //Task<AML_LineStatus> GetByBuildNoAsync(string buildNo);

        Task SaveAsync(BuildItem buildItem, AML_LineStatus newLineStatus);
        //Task SaveAsync(AML_LineStatus oldLineStatus, AML_LineStatus newLineStatus);

    }
}
