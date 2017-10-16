
using EleksRssCore;
using Prism.Events;
using System.Collections.Generic;

namespace DesktopMainModule
{
    class RssItemsListChangedEvent : PubSubEvent<List<RssItem>>
    {
    }
}
