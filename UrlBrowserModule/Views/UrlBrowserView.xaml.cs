using System.Windows.Controls;

namespace UrlBrowserModule
{
    public partial class UrlBrowserView : UserControl
    {
        public UrlBrowserView(UrlBrowserViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
