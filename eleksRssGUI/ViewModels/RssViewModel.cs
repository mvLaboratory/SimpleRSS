﻿using System;
using EleksRssCore;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace eleksRssGUI
{
    class RssViewModel : BaseViewModel
    {


        public RssViewModel()
        {
            ObservableCategories = new ObservableCategories();
            ObservableRssItems = new ObservableRssItems();

            //new StorageManager();
            //updateItems();
        }

        public override TestDelegate GetDelegate()
        {
            return new TestDelegate(test);
        }

        async Task updateItems()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                ObservableRssItems.Add(new RssItem("Sensation N" + i, "I am", "http", new Category("first", "")));
            }
        }

        public void test(IModel model)
        {
            ObservableRssItems.Add(model);
        }
    }
}
