using System;
using System.Collections.Generic;
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

        public Category(Int64 id, String name, String url)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

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

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null &&
                   Id == category.Id &&
                   Name == category.Name &&
                   RssURL == category.RssURL;
        }

        public override int GetHashCode()
        {
            var hashCode = 1169894586;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RssURL);
            return hashCode;
        }

        private static long _lastId;
    }
}
