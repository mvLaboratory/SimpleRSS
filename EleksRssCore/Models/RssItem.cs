using System;

namespace EleksRssCore
{
    public class RssItem
    {
        public DateTime PublicationdDate { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String Url { get; set; }
        public Category Category { get; set; }

        public RssItem(DateTime publicationdDate, String title, String author, String url, Category category)
        {
            PublicationdDate = publicationdDate;
            Title = title;
            Author = author;
            Url = url;
            Category = category;
        }

        public RssItem(String title, String author, String url, Category category) : this (DateTime.Now, title, author, url, category)
        {
        }
    }
}
