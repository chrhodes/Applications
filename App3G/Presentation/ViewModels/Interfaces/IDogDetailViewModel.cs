using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace App3.Presentation.ViewModels
{
    public interface IDogDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
