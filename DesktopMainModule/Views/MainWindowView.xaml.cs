using System.Windows.Controls;

namespace DesktopMainModule
{
    public partial class MainWindowView : UserControl
    {
        public MainWindowView(RssViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
