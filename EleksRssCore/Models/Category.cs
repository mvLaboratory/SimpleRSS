using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EleksRssCore
{
    [Table("Category")]
    public class Category : IModel, ICategory
    {
        [Column("Id")]
        [Key]
        public Int64 Id { get; set; }

        [Column("Name")]
        public String Name { get; set; }

        [Column("RssURL")]
        public String RssURL { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public Category(long id, String name, String url)
        {
            Id = id;
            Name = name;
            RssURL = url;
            CreationDate = DateTime.Now;

            _lastId = id;
        }

        public Category(String name, String url) :this (++_lastId, name, url)
        {

        }

        public Category() : this(++_lastId, "", "")
        {

        }

        public override string ToString()
        {
            return Name;
        }

        private static long _lastId;
    }
}
