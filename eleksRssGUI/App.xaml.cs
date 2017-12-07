﻿using EleksRssCore;
using System.Windows;

namespace eleksRssGUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new Bootstrapper().Run();
        }
    }
}
