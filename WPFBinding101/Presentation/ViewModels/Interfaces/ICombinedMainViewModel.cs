using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace .Presentation.ViewModels
{
    public interface ICombinedMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
