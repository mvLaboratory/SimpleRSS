using System.Collections.Generic;

namespace EleksRssCore
{
    public class RssDataSaver: IDataSaver
    {
        public RssDataSaver(StorageManager storageManager)
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
            _storageManager.SaveRssItems();
            return true;
        }

        private StorageManager _storageManager;
    }
}
