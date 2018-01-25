using System;
using System.Collections.Generic;
using System.Linq;

namespace EleksRssCore
{
    public class StorageManager : IStorageManager
    {
        public RssStorage Storage { get; private set; }
        public UnitOfWork UnitOfWork { get; set; }

        public StorageManager(UnitOfWork unitOfWork, RssStorage storage)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            Storage = storage ?? throw new ArgumentNullException("storage");
        }

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

            var localPageCount = ApplicationStateManager.pageCount = Storage.FeedItems
                .Count(item => item.Category != null && item.Category.Id == currentCaregory.Id);

            ApplicationStateManager.pageCount = localPageCount;

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
             return UnitOfWork.CategoryRepository.Get().ToList();
        }

        public void SaveRssItem(RssItem itemForSave)
        {            
            if (Storage.FeedItems.Any(item => item.Url.Equals(itemForSave.Url)))
                return;

            UnitOfWork.FeedRepository.context.FeedItems.Attach(itemForSave);
            UnitOfWork.FeedRepository.Insert(itemForSave);
        }

        public void SaveFeedItems()
        {
            UnitOfWork.Save();
        }

        public void SaveCategory(Category item)
        {
            UnitOfWork.CategoryRepository.Insert(item);
            UnitOfWork.Save();
        }

        public void DeleteOldNews()
        {
            var date = DateTime.Now.AddMonths(-3);
            UnitOfWork.FeedRepository.Delete(item => item.PublicationdDate < date);
            UnitOfWork.Save();
        }

        private static DateTime lastReadedDate;
    }
}
