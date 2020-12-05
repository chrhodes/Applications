using VNC.Core.Mvvm;

namespace ModuleInterfaces
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);
    }
}
