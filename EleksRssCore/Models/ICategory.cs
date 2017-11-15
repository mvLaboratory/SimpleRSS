using System;

namespace EleksRssCore
{
    public interface ICategory
    {
        Int64 Id { get; set; }
        String Name { get; set; }
        String RssURL { get; set; }
        DateTime CreationDate { get; set; }
    }
}
