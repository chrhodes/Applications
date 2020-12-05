using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.Dog.ViewModels
{
    public interface IDogViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
