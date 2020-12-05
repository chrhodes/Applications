using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IViewModel
    {
        // Normally in MVVM a ViewModel does not know about the view
        // Here we are using an Interface so there is still separation
        IView View { get; set; }
    }
}
