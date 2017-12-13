using EleksRssCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class IDataSaverFake : IDataSaver
    {
        public IDataSaverFake(IStorageStub storage)
        {
            _storage = storage;
        }

        public void saveCategory(Category item)
        {
            _storage.Categories.Add(item);
        }

        public bool saveRssItems(List<RssItem> items)
        {
            _storage.Items.AddRange(items);
            return true;
        }

        private IStorageStub _storage;
    }
}
