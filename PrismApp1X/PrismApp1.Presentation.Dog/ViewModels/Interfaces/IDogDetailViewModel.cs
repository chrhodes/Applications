using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Dog.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
