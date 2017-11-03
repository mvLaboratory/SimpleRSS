using EleksRssCore;
using Prism.Events;
using System.Collections.Generic;

namespace GuiEnvironment
{
    public class RssItemsListChangedEvent : PubSubEvent<List<RssItem>>
    {
    }
}
