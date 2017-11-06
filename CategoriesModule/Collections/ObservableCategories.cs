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
            UpdateCategoriesList(_dataProvider.readRssCategories());
        }

        public void CategoriesListChangedHandler(Category item)
        {
            this.Add(item);
        }

        public void UpdateCategoriesList(List<Category> items)
        {
            Clear();
            this.AddRange(items);
        }

        public bool CategoriesListEventFilter(Category items)
        {
            return true;
        }

        private readonly IDataProvider _dataProvider;
    }
}
