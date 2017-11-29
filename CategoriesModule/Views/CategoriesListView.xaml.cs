using System.Windows.Controls;

namespace CategoriesModule
{
    public partial class CategoriesListView : UserControl
    {
        public CategoriesListView(ICategoriesListViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
