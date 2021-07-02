using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAEF1a.Presentation.ViewModels
{
    public interface ICatNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
