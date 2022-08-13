using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAEF2.Presentation.ViewModels
{
    public interface ICarNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
