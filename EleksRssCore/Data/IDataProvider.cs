using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IDataProvider
    {
        List<RssItem> readRssItems();
        List<RssItem> readRssItems(Category category);
        List<Category> readRssCategories();
    }
}
