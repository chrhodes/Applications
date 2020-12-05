using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace TestPrismApp1.Presentation.ViewModels
{
    public interface IDogViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
