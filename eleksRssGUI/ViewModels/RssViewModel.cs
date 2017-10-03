using System;
using EleksRssCore;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace eleksRssGUI
{
    class RssViewModel : BaseViewModel
    {
        public ObservableCollection<IModel> ObservableCategories { get; private set; }
        public ObservableCollection<IModel> ObservableRssItems { get; private set; }

        public RssViewModel(IDataProvider dataProvider)
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
