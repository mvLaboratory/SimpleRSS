using System;

namespace EleksRssCore
{
    public class Category
    {
        public String Name { get; set; }
        public String RssURL { get; set; }

        public Category(String name, String url)
        {
            Name = name;
            RssURL = url;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
