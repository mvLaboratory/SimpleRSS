using EleksRssCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    class IDataProviderFake : IDataProvider
    {
        public IDataProviderFake(IStorageStub storage)
        {
            _storage = storage;
        }

        public List<RssItem> delete_readRssItems(Category category)
        {
            return _storage.Items.Where(item => (item.Category == category)).ToList();
        }

        public List<Category> readRssCategories()
        {
            return _storage.Categories;
        }

        public List<RssItem> readRssItems()
        {
            return _storage.Items;
        }

        private IStorageStub _storage;
    }
}
