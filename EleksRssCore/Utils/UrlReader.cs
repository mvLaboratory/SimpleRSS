using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EleksRssCore
{
    public class UrlReader : IUrlReader
    {
        public SyndicationFeed ReadUrl(String url)
        {
            SyndicationFeed result = null;

            using (var reader = XmlReader.Create(url))
            {
                result = SyndicationFeed.Load(reader);
            }
            return result;
        }
    }
}
