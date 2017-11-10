using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EleksRssCore
{
    class RssDataReader
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
                    
                }
            });
            var url = "https://www.upwork.com/ab/feed/jobs/rss?subcategory2=game_development&sort=renew_time_int+desc&api_params=1&q=&securityToken=de8019fa5e3e0eb70d564fddb76793459d9cc6a3e2c6cb2641c25f651825ed18c00c836e25612cefd9790ce91dbd0eff7968ebbe03c5de88aa09494996127efe&userUid=673839277975281664&orgUid=673839277979475969";        
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

        private static bool saveRssFeed(SyndicationFeed rssFeed, IDataSaver dataSaver)
        {
            rssFeed.Items.OrderBy(item => item.PublishDate.DateTime).ToList().ForEach(item => dataSaver.saveRssItems(new RssItem(item.PublishDate.DateTime, item.Title.Text, "", item.Id, null)));
            return true;
        }
    }
}
