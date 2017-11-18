﻿using DesktopMainModule;
using EleksRssCore;
using GuiEnvironment;
using Microsoft.Practices.Unity;
using PagingModule;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace eleksRssGUI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Container.RegisterType<BaseViewModel, RssViewModel>();
            Container.RegisterType<IDataProvider, RssDataProvider>();
            Container.RegisterType<IDataUpdater, DataUpdater>();
            Container.RegisterType<IDataSaver, RssDataSaver>();
            Container.RegisterType<IStorageManager, StorageManager>();
            Container.RegisterType<ICategory, Category>();
            Container.RegisterType<IFeedItem, RssItem>();
            Container.RegisterType<IPagingViewModule, PagingViewModule>();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            var newsModule = typeof(DesktopMainModule.DesktopMainModule);
            var urlBrowserModule = typeof(UrlBrowserModule.UrlBrowserModule);
            var categoriesModule = typeof(CategoriesModule.CategoriesModule);
            var pagingModule = typeof(PagingModule.PagingModule);

            moduleCatalog.AddModule(newsModule);
            moduleCatalog.AddModule(urlBrowserModule);
            moduleCatalog.AddModule(categoriesModule);
            moduleCatalog.AddModule(pagingModule);
        }
    }
}
