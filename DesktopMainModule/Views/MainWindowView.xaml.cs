using GuiEnvironment;
using Prism.Regions;
using System;
using System.Windows;
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
