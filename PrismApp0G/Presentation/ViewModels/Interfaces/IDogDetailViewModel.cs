using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp0.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
