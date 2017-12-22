using System.Windows;

namespace eleksRssGUI
{
    public partial class Shell : Window
    {
        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
