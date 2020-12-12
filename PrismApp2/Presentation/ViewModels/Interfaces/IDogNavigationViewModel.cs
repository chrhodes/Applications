using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.ViewModels
{
    public interface IDogNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
