using EleksRssCore;
using System.Collections.Generic;

namespace GuiEnvironment
{
    public interface IDataProvider
    {
        List<RssItem> readRssItems();
        List<Category> readRssCategories();
    }
}
