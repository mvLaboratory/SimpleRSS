using System;
using System.Windows;

namespace eleksRssGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IViewModelFactory modelViewFactory = new ViewModelFactory();
            DataContext = modelViewFactory.GetRssViewModel();
        }
    }
}
