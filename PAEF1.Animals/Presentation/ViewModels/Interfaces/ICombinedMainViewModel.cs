using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PAEF1.Animals.Presentation.ViewModels
{
    public interface ICombinedMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
