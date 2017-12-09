using EleksRssCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class IDataReaderFake : IDataProvider
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
