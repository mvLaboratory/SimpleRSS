using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IDataSaver
    {
        void saveCategory(Category item);
        bool saveRssItems(List<RssItem> items);
    }
}
