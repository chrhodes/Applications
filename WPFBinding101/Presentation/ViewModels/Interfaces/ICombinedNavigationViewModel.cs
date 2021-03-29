using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace .Presentation.ViewModels
{
    public interface ICombinedNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
