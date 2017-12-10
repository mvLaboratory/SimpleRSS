using System;
using System.ServiceModel.Syndication;

namespace EleksRssCore
{
    public interface IUrlReader
    {
        SyndicationFeed ReadUrl(String url);
    }
}
