using System;
using System.ComponentModel.DataAnnotations;

namespace EleksRssCore
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public String Name { get; set; }
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
