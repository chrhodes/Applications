using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.ViewModels
{
    public interface ICatMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
