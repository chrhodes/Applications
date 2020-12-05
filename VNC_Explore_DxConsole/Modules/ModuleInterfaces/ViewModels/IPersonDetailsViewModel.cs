using VNC.Core.Mvvm;
using PrismDemo.Domain;

namespace ModuleInterfaces
{
    public interface IPersonDetailsViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
