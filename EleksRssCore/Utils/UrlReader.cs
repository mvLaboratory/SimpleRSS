using System;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EleksRssCore
{
    public class UrlReader : IUrlReader
    {
        public SyndicationFeed ReadUrl(String url)
        {
            SyndicationFeed result = null;

            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    result = SyndicationFeed.Load(reader);
                }
            }
            catch (WebException ex)
            {
                //TODO:: log it
            }
            return result;
        }
    }
}
