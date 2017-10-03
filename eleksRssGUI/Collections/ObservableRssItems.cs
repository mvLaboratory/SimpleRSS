using System;
using EleksRssCore;
using System.Collections.ObjectModel;

namespace eleksRssGUI 
{
    class ObservableRssItems : ObservableCollection<IModel>
    {
        public ObservableRssItems()
        {
            Add(new RssItem("Sensation1", "I am", "http", new Category("first", "")));
            Add(new RssItem("Sensation2", "I am", "http", new Category("first", "")));
            Add(new RssItem("Sensation3", "I am", "http", new Category("first", "")));
            Add(new RssItem("Sensation4", "I am", "http", new Category("first", "")));
        }
    }
}
