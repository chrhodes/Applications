using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace PrismApp2.Presentation.ViewModels
{
    public interface IDogMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
