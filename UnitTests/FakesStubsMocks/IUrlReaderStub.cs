using System.ServiceModel.Syndication;
using EleksRssCore;
using System.Collections.Generic;
using System;

namespace UnitTests
{
    class IDataReaderStub : IUrlReader
    {
        public SyndicationFeed ReadUrl(string url)
        {
            List<SyndicationItem> items = new List<SyndicationItem>();
            switch (url)
            {
                case "url1":
                    {
                        SyndicationItem item1 = new SyndicationItem();
                        item1.Title = new TextSyndicationContent("Item 1");
                        item1.Summary = new TextSyndicationContent("This is Item 1's summary");
                        item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
                        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
                        items.Add(item1);
                        break;
                    }
                case "url2":
                    {
                        SyndicationItem item2 = new SyndicationItem();
                        item2.Title = new TextSyndicationContent("Item 2");
                        item2.Summary = new TextSyndicationContent("This is Item 2's summary");
                        item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
                        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
                        items.Add(item2);
                        break;
                    }
            }       

            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now, items);

            return feed;
        }
    }
}
