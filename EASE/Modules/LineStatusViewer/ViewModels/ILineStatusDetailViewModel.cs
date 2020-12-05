using LineStatusViewer.Models;
using System.Threading.Tasks;

namespace LineStatusViewer.ViewModels
{
    public interface ILineStatusDetailViewModel
    {
        Task LoadAsync(BuildItem buildItem);
        //Task LoadAsync(string buildNo);
    }
}