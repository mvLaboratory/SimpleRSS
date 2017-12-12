using EleksRssCore;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    class IDataProviderFake : IDataProvider
    {
        public List<RssItem> delete_readRssItems(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> readRssCategories()
        {
            throw new NotImplementedException();
        }

        public List<RssItem> readRssItems()
        {
            throw new NotImplementedException();
        }
    }
}
