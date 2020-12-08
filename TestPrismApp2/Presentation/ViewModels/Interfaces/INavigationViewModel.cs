using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace TestPrismApp2.Presentation.ViewModels
{
    public interface INavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
