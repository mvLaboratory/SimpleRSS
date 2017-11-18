using System.Windows.Controls;

namespace PagingModule
{
    public partial class PagingView : UserControl
    {
        public PagingView(IPagingViewModule model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
