using EleksRssCore;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    class IStorageStub
    {
        public List<Category> Categories{ 
            get 
            {
                return _categories;
            }
        }

        public List<RssItem> Items
        {
            get
            {
                return _items;
            }
        }

        public IStorageStub()
        {
            _cat1 = new Category("Category1", "url1");
            _cat2 = new Category("Category2", "url2");
            _categories = new List<Category> { _cat1, _cat2 };

            _item1 = new RssItem(DateTime.MinValue, "title1", "author1", "url1", _cat1);
            _item2 = new RssItem(DateTime.Now, "title2", "author2", "url2", _cat2);
            _item3 = new RssItem(DateTime.MaxValue, "title3", "author3", "url3", _cat1);
            _items = new List<RssItem> { _item1, _item2, _item3 };
        }

        private Category _cat1;
        private Category _cat2;
        private RssItem _item1;
        private RssItem _item2;
        private RssItem _item3;
        private List<Category> _categories;
        private List<RssItem> _items;
    }
}
