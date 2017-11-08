using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IStorageManager
    {
        List<RssItem> readRssItems();

        List<RssItem> readRssItems(Category currentCaregory);

        List<Category> readRssCategoriesItems();

        void SaveRssItem(RssItem item);

        void SaveCategory(Category item);
    }
}
