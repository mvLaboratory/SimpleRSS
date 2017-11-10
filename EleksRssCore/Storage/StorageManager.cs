using System;
using System.Collections.Generic;
using System.Linq;

namespace EleksRssCore
{
    public class StorageManager : IStorageManager
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

        public List<IFeedItem> readRssItems()
        {
            var newItems = Storage.FeedItems.Take(10).OrderByDescending(item => item.PublicationdDate).ToList();
            if (newItems.Any())
            {
                lastReadedDate = newItems.Max(item => item.PublicationdDate);
            }
            return newItems;
        }

        public List<IFeedItem> readRssItems(ICategory currentCaregory)
        {
            var newItems = Storage.FeedItems.Where(item => item.Category == currentCaregory).Take(10).OrderByDescending(item => item.PublicationdDate).ToList();
            if (newItems.Any())
            {
                lastReadedDate = newItems.Max(item => item.PublicationdDate);
            }
            return newItems;
        }

        public List<ICategory> readRssCategoriesItems()
        {
            return Storage.Categories.ToList();
        }

        public void SaveRssItem(IFeedItem item)
        {
            if (item.PublicationdDate <= lastLoadedDate)
                return;

            Storage.RssItems.Add(item);
            Storage.SaveChangesAsync();
            lastLoadedDate = item.PublicationdDate;
        }

        public void SaveCategory(ICategory item)
        {
            Storage.Categories.Add(item);
            Storage.SaveChanges();
        }

        private static DateTime lastReadedDate;
        private static DateTime lastLoadedDate;
    }
}
