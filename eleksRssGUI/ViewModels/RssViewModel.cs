using System;
using EleksRssCore;
using System.Threading.Tasks;

namespace eleksRssGUI
{
    class RssViewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }
        public ObservableRssItems ObservableRssItems { get; private set; }

        public RssViewModel()
        {
            ObservableCategories = new ObservableCategories();
            ObservableRssItems = new ObservableRssItems();


            new StorageManager();
            updateItems();


        }

        async Task updateItems()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                ObservableRssItems.Add(new RssItem("Sensation N" + i, "I am", "http", new Category("first", "")));
            }
        }
    }
}
