using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismEFI2.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
