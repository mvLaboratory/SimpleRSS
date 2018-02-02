using NLog;
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
            _logger.Debug("readRssItems: Start");

            Int32 currentPage = ApplicationStateManager.currentPage - 1;
            Int32 itemsPerPage = ApplicationStateManager.itemsPerPage;
            var newItems = Storage.FeedItems.Skip(currentPage * itemsPerPage).Take(itemsPerPage).OrderByDescending(item => item.PublicationdDate).ToList();
            if (newItems.Any())
            {
                lastReadedDate = newItems.Max(item => (item).PublicationdDate);
            }
            _logger.Debug("readRssItems: Finish");

            return newItems;
        }

        public List<RssItem> readRssItems(Category currentCaregory)
        {
            _logger.Debug("readRssItems: Start");
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
            _logger.Debug("readRssItems: Finish");

            return newItems;
        }

        public List<Category> readRssCategoriesItems()
        {
            return UnitOfWork.CategoryRepository.Get().ToList();
        }

        public void SaveRssItem(RssItem itemForSave)
        {
            if (Storage.FeedItems.Any(item => item.Url.Equals(itemForSave.Url)))
            {
                return;
            }

            _logger.Debug("SaveRssItem: saving " + itemForSave);
            UnitOfWork.FeedRepository.context.FeedItems.Attach(itemForSave);
            UnitOfWork.FeedRepository.Insert(itemForSave);
            _logger.Debug("SaveRssItem: Finish");
        }

        public void SaveFeedItems()
        {
            _logger.Debug("SaveFeedItems: Start");
            UnitOfWork.Save();
            _logger.Debug("SaveFeedItems: Finish");
        }

        public void SaveCategory(Category item)
        {
            _logger.Debug("SaveCategory: Start");
            UnitOfWork.CategoryRepository.Insert(item);
            UnitOfWork.Save();
            _logger.Debug("SaveCategory: Finish");
        }

        public void DeleteOldNews()
        {
            var date = DateTime.Now.AddMonths(-3);
            UnitOfWork.FeedRepository.Delete(item => item.PublicationdDate < date);
            UnitOfWork.Save();
        }

        private static DateTime lastReadedDate;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
