using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineStatusViewer.Events
{
    public class AfterLineStatusSavedEvent : PubSubEvent<AfterLineStatusSavedEventArgs>
    {
    }
}
