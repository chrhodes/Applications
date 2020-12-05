using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IView
    {
        // This is for ViewModel first approaches
        IViewModel ViewModel { get; set; }
    }
}
