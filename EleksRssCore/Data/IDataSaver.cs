using System.Collections.Generic;

namespace EleksRssCore
{
    public interface IDataSaver
    {
        void saveCategory(Category item);
        bool saveRssItems(ICollection<IFeedItem> items);
    }
}
