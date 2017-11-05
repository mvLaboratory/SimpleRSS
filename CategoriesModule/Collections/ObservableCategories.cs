using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EleksRssCore;
using GuiEnvironment;

namespace DesktopMainModule
{
    public class ObservableCategories : ObservableCollection<Category>
    {
        public ObservableCategories(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            CategoriesListChangedHandler(_dataProvider.readRssCategories());
        }

        public void CategoriesListChangedHandler(List<Category> items)
        {
            Clear();
            this.AddRange(items);
        }

        public bool RssItemsListEventFilter(List<Category> items)
        {
            return true;
        }

        private readonly IDataProvider _dataProvider;
    }
}
