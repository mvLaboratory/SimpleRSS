using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EleksRssCore
{
    [Table("RssItem")]
    public class RssItem : IModel, IFeedItem
    {
        [Column("Id")]
        [Key]
        public Int64 Id { get; set; }

        [Column("PublicationdDate")]
        public DateTime PublicationdDate { get; set; }

        [Column("Title")]
        public String Title { get; set; }

        [Column("Author")]
        public String Author { get; set; }

        [Column("Url")]
        public String Url { get; set; }

        [Column("Category")]
        public Category Category { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public RssItem(long id, DateTime publicationdDate, String title, String author, String url, Category category)
        {
            if (id < 0)
            {
                throw new ArgumentException("id");
            }

            Id = id;
            PublicationdDate = publicationdDate;
            Title = title;
            Author = author;
            Url = url;
            Category = category;
            CreationDate = DateTime.Now;

            _lastId = id;
        }

        public RssItem(DateTime publicationdDate, String title, String author, String url, Category category)
            : this(++_lastId, publicationdDate, title, author, url, category)
        {
        }

        public RssItem(String title, String author, String url, Category category) 
            : this (++_lastId, DateTime.Now, title, author, url, category)
        {
        }

        public RssItem() : this("", "", "", null)
        {

        }

        public override String ToString()
        {
            return Title;
        }

        private static long _lastId;
    }
}
