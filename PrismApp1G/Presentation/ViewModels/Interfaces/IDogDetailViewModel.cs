using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
