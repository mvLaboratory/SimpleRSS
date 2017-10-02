using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EleksRssCore
{
    [Table("Category")]
    public class Category
    {
        [Column("Id")]
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        public String Name { get; set; }

        [Column("RssURL")]
        public String RssURL { get; set; }

        public Category(long id, String name, String url)
        {
            Id = id;
            Name = name;
            RssURL = url;

            _lastId = id;
        }

        public Category(String name, String url) :this (++_lastId, name, url)
        {

        }

        public override string ToString()
        {
            return Name;
        }

        private static long _lastId;
    }
}
