using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
