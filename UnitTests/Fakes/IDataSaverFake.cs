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
        public void saveCategory(Category item)
        {
            throw new NotImplementedException();
        }

        public bool saveRssItems(List<RssItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
