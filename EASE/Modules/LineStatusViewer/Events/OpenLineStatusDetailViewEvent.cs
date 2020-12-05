using LineStatusViewer.Models;
using Prism.Events;

namespace LineStatusViewer.Events
{
    //public class OpenLineStatusDetailViewEvent : PubSubEvent<string>
    //{
    //}

    public class OpenLineStatusDetailViewEvent : PubSubEvent<BuildItem>
    {
    }
}
