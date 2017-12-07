using System;
using System.Collections.Generic;

namespace EleksRssCore
{
    public class RssDataProvider : IDataProvider
    {
        public RssDataProvider(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public List<RssItem> readRssItems()
        {
            var items = _storageManager.readRssItems(ApplicationStateManager.currentCategory);
            var result = new List<RssItem>();
            foreach(var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public List<RssItem> delete_readRssItems(Category category)
        {
            var items = _storageManager.readRssItems(category);
            var result = new List<RssItem>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public List<Category> readRssCategories()
        {
            var items = _storageManager.readRssCategoriesItems();
            var result = new List<Category>();
            foreach (var item in items)
            {
                if (ApplicationStateManager.currentCategory == null)
                {
                    ApplicationStateManager.currentCategory = item;
                }
                result.Add(item);
            }

            return result;
        }

        private IStorageManager _storageManager; 
    }
}
