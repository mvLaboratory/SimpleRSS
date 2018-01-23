using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace EleksRssCore
{
    public class RssDataReader : IDataReader
    {
        public RssDataReader(IDataProvider dataProvider, IDataSaver dataSaver, IUrlReader urlReader)
        {
            _urlReader = urlReader ?? throw new ArgumentNullException("urlReader");
            _dataProvider = dataProvider ?? throw new ArgumentNullException("dataProvider");
            _dataSaver = dataSaver ?? throw new ArgumentNullException("dataSaver");
        }

        public void Read()
        {
            List<Category> categoriesList = _dataProvider.readRssCategories();
            categoriesList.ForEach(cat =>
            {
                String _url = cat.RssURL;
                SyndicationFeed rssFeed = _urlReader.ReadUrl(_url);

                if (rssFeed != null && rssFeed.Items.Any())
                {
                    saveRssFeed(rssFeed, _dataSaver, cat);
                }
            });      
        }

        private static bool saveRssFeed(SyndicationFeed rssFeed, IDataSaver dataSaver, Category category)
        {
            List<RssItem> rssItems = rssFeed.Items.OrderBy(item => item.PublishDate.DateTime).Select(item => new RssItem(item.PublishDate.DateTime, item.Title.Text, "", item.Id, category)).ToList();

            dataSaver.saveRssItems(rssItems);
            return true;
        }

        private readonly IUrlReader _urlReader;
        private readonly IDataSaver _dataSaver;
        private readonly IDataProvider _dataProvider;
    }
}
