using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IStorageManager
    {
        List<IFeedItem> readRssItems();

        List<IFeedItem> readRssItems(ICategory currentCaregory);

        List<ICategory> readRssCategoriesItems();

        void SaveRssItem(IFeedItem item);

        void SaveCategory(ICategory item);
    }
}
