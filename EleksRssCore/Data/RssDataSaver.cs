using NLog;
using System;
using System.Collections.Generic;

namespace EleksRssCore
{
    public class RssDataSaver: IDataSaver
    {
        public RssDataSaver(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public void saveCategory(Category item)
        {
            _storageManager.SaveCategory(item);
        }

        public bool saveRssItems(List<RssItem> items)
        {
            try
            {
                items.ForEach(item => _storageManager.SaveRssItem(item));
                _storageManager.SaveFeedItems();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return true;
        }

        private IStorageManager _storageManager;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
