using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            items.ForEach(item => _storageManager.UnitOfWork.FeedRepository.Insert(item));
            _storageManager.UnitOfWork.Save();
            return true;
        }

        private StorageManager _storageManager;
    }
}
