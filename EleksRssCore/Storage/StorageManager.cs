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
            if (Storage.RssItems.Any())
            {
                lastLoadedDate = Storage.RssItems.Max(item => item.PublicationdDate);
            }
        }

        public List<RssItem> readRssItems()
        {
            var newItems = Storage.RssItems.Take(10).OrderByDescending(item => item.PublicationdDate).ToList();
            if (newItems.Any())
            {
                lastReadedDate = newItems.Max(item => item.PublicationdDate);
            }
            return newItems;
        }

        public List<Category> readRssCategoriesItems()
        {
            return Storage.Categories.ToList();
        }

        public void SaveRssItem(RssItem item)
        {
            if (item.PublicationdDate <= lastLoadedDate)
                return;

            Storage.RssItems.Add(item);
            Storage.SaveChangesAsync();
            lastLoadedDate = item.PublicationdDate;
        }

        private static DateTime lastReadedDate;
        private static DateTime lastLoadedDate;
    }
}
