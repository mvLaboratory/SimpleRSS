using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksRssCore
{
    public class StorageManager
    {
        public RssStorage Storage { get; private set; }
        //ToDo manage instance
        public StorageManager()
        {
            Storage = new RssStorage();

            Category defaultCategory = new Category("default", "");
            Storage.Categories.Add(defaultCategory);
            Storage.SaveChanges();
        }
    }
}
