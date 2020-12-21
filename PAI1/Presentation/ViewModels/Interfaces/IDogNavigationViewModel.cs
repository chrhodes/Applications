using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAI1.Presentation.ViewModels
{
    public interface IDogNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
