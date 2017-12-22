using System.Windows.Controls;

namespace DesktopMainModule
{
    public partial class MainWindowView : UserControl
    {
        public MainWindowView(IFeedViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
