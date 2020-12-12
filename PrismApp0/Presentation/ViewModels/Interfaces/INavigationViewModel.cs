using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp0.Presentation.ViewModels
{
    public interface INavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
