using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismEFI2.Presentation.ViewModels
{
    public interface IDogNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
