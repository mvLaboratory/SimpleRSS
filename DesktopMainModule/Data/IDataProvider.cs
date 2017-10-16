using EleksRssCore;
using System.Collections.Generic;

namespace DesktopMainModule
{
    public interface IDataProvider
    {
        List<RssItem> readRssItems();
    }
}
