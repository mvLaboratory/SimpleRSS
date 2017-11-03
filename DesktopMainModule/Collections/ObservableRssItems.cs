using EleksRssCore;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace DesktopMainModule
{
    public class ObservableRssItems : ObservableCollection<RssItem>
    {
        public ObservableRssItems()
        {
        }

        public void RssItemsListChangedHandler(List<RssItem> items)
        {
            Clear();
            this.AddRange(items);
        }

        public bool RssItemsListEventFilter(List<RssItem> items)
        {
            return true;
        }
    }
}
