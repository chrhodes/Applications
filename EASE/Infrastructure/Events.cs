using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Practices.Prism.Events;
using Prism;
using Prism.Events;

namespace Infrastructure
{
    // Removed in Prism6
    //public class PersonUpdatedEvent : CompositePresentationEvent<string> { }
    public class PersonUpdatedEvent : PubSubEvent<string> { }
}
