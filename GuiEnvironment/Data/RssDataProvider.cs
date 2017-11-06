using EleksRssCore;
using GuiEnvironment;
using System.Collections.Generic;

namespace GuiEnvironment
{
    public class RssDataProvider : IDataProvider
    {
        public RssDataProvider(StorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public List<RssItem> readRssItems()
        {
            return _storageManager.readRssItems(ApplicationStateManager.currentCategory);
        }

        public List<Category> readRssCategories()
        {
            return _storageManager.readRssCategoriesItems();
        }

        private StorageManager _storageManager; 
    }
}
