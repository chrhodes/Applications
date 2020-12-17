using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismAppEF5.Presentation.ViewModels
{
    public interface ICombinedNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
