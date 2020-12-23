using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismAppEF1.Presentation.ViewModels
{
    public interface IBirdDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
