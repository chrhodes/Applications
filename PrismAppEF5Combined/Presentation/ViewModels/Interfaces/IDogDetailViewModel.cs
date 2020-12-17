using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismAppEF5.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
