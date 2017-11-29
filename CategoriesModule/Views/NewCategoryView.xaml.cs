using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CategoriesModule
{
    public partial class NewCategoryView : UserControl
    {
        public NewCategoryView(INewCategoryViewModel viewModule)
        {
            InitializeComponent();
            DataContext = viewModule;
        }
    }
}
