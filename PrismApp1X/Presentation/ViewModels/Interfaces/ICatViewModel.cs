using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ViewModels
{
    public interface ICatViewModel : IViewModel
    {
        // TODO(crhodes)
        // Add items here that the CatViewModel must support
        // to enable all the binding demands of the View

        Task LoadAsync();
    }
}
