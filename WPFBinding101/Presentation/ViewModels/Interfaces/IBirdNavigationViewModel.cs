using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace WPFBinding101.Presentation.ViewModels
{
    public interface IBirdNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
