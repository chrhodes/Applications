using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp3.Presentation.ViewModels
{
    public interface IDogNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
