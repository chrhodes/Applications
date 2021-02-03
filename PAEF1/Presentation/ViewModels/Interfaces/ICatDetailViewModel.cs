using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAEF1.Presentation.ViewModels
{
    public interface ICatDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
