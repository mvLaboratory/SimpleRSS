using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopMainModule
{
    public partial class MainWindowView : UserControl
    {
        public MainWindowView(BaseViewModel model)
        {
            InitializeComponent();

            _model = model;
            DataContext = model;
        }

        private void ListItemDoubleClickHandler(object sender, RoutedEventArgs e)
        {
            if (((MouseButtonEventArgs)e).ClickCount >= 2 && (sender is FrameworkElement))
            {
                FrameworkElement senderPanel = (FrameworkElement)sender;
                ICommand command = _model.GetCommand("RssItemDbClick");

                if (command != null)
                {
                    command.Execute(senderPanel.Tag);
                }
            }
        }

        private BaseViewModel _model;
    }
}
