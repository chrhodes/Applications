using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAEF3.Presentation.ViewModels
{
    public interface ICombinedNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
