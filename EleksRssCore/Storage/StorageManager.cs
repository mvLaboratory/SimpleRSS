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

        //public void readModels()
        //{
        //    Storage.Categories.ToList();
        //}

        public List<RssItem> readRssItems()
        {
            return Storage.RssItems.ToList();
        }
    }
}
