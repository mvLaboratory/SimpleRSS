using System;
using System.Collections.ObjectModel;
using EleksRssCore;

namespace eleksRssGUI
{
    class ObservableCategories : ObservableCollection<IModel>
    {
        public ObservableCategories()
        {
            Add(new Category("First", "First Category"));
            Add(new Category("Second", "Second Category"));
            Add(new Category("Third", "Third Ctegory"));
        }
    }
}
