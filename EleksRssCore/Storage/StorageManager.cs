using System;
using System.Collections.Generic;
using System.Linq;

namespace EleksRssCore
{
    public class StorageManager
    {
        public RssStorage Storage { get; private set; }
        //TODO:: manage instance
        public StorageManager()
        {
            Storage = new RssStorage();
        }

        public List<RssItem> readRssItems()
        {
            return Storage.RssItems.ToList();
        }

        public void SaveRssItem(RssItem item)
        {
            Storage.RssItems.Add(item);
            Storage.SaveChangesAsync();
        }
    }
}
