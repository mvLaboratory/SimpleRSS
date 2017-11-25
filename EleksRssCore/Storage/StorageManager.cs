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
            UnitOfWork = new UnitOfWork();
            Storage = (RssStorage) UnitOfWork.RssStorage;
        }

        public UnitOfWork UnitOfWork { get; set; }

        public List<RssItem> readRssItems()
        {
            Int32 currentPage = ApplicationStateManager.currentPage - 1;
            Int32 itemsPerPage = ApplicationStateManager.itemsPerPage;
            var newItems = Storage.FeedItems.Skip(currentPage * itemsPerPage).Take(itemsPerPage).OrderByDescending(item => item.PublicationdDate).ToList();
            if (newItems.Any())
            {
                lastReadedDate = newItems.Max(item => (item).PublicationdDate);
            }
            return newItems;
        }

        public List<RssItem> readRssItems(Category currentCaregory)
        {
            if (currentCaregory == null)
            {
                return new List<RssItem>();
            }
            ApplicationStateManager.pageCount = Storage.FeedItems.Count();
            Int32 currentPage = ApplicationStateManager.currentPage - 1;
            Int32 itemsPerPage = ApplicationStateManager.itemsPerPage;

            var newItems = Storage.FeedItems
                .Where(item => item.Category != null && item.Category.Id == currentCaregory.Id)
                .OrderByDescending(item => item.PublicationdDate)
                .Skip(currentPage * itemsPerPage).Take(itemsPerPage)
                .ToList();
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

        public void SaveRssItem(RssItem itemForSave)
        {            
            if (Storage.FeedItems.Any(item => item.Url.Equals(itemForSave.Url)))
                return;

            UnitOfWork.FeedRepository.Insert(itemForSave);
        }

        public void SaveRssItems()
        {
            UnitOfWork.Save();
        }

        public void SaveCategory(Category item)
        {
            Storage.Categories.Add(item);
            Storage.SaveChanges();
        }

        private static DateTime lastReadedDate;
    }
}
