using System;

namespace EleksRssCore
{
    public interface IFeedItem
    {
        Int64 Id { get; set; }
        DateTime PublicationdDate { get; set; }
        String Title { get; set; }
        String Author { get; set; }
        String Url { get; set; }
        Category Category { get; set; }
        DateTime CreationDate { get; set; }
    }
}
