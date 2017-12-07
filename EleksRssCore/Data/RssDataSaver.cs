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
            items.ForEach(item => _storageManager.SaveRssItem(item));
            _storageManager.SaveFeedItems();
            return true;
        }

        private IStorageManager _storageManager;
    }
}
