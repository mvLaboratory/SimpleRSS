using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IDataProvider
    {
        List<RssItem> readRssItems();
        List<Category> readRssCategories();
    }
}
