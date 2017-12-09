using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EleksRssCore
{
    public class RssDataReader
    {
        public static void Read(IDataProvider dataProvider, IDataSaver dataSaver)
        {
            List<Category> categoriesList = dataProvider.readRssCategories();
            categoriesList.ForEach(cat =>
            {
                var _url = cat.RssURL;
                var rssFeed = readUrl(_url);
                if (rssFeed != null && rssFeed.Items.Any())
                {
                    saveRssFeed(rssFeed, dataSaver, cat);
                }
            });      
        }

        private static SyndicationFeed readUrl(String url)
        {
            SyndicationFeed result = null;

            using (var reader = XmlReader.Create(url))
            {
                result = SyndicationFeed.Load(reader);
            }
            return result;
        }

        private static bool saveRssFeed(SyndicationFeed rssFeed, IDataSaver dataSaver, Category category)
        {
            List<RssItem> rssItems = rssFeed.Items.OrderBy(item => item.PublishDate.DateTime).Select(item => new RssItem(item.PublishDate.DateTime, item.Title.Text, "", item.Id, category)).ToList();

            dataSaver.saveRssItems(rssItems);
            return true;
        }
    }
}
