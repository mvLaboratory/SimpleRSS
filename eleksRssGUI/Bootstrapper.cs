using CategoriesModule;
using DesktopMainModule;
using EleksRssCore;
using GuiEnvironment;
using Microsoft.Practices.Unity;
using NLog;
using PagingModule;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;
using UrlBrowserModule;

namespace eleksRssGUI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Shell(new ShellViewModule());
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            IUnityContainer Container = new UnityContainer();
            Container.RegisterType<IDataProvider, RssDataProvider>();
            Container.RegisterType<IDataUpdater, DataUpdater>();
            Container.RegisterType<IDataSaver, RssDataSaver>();
            Container.RegisterType<IStorageManager, StorageManager>();
            Container.RegisterType<IDataReader, RssDataReader>();
            Container.RegisterType<IUrlReader, UrlReader>();
            Container.RegisterType<ICategory, Category>();
            Container.RegisterType<IFeedItem, RssItem>();
            Container.RegisterType<IPagingViewModule, PagingViewModule>();
            Container.RegisterType<IShellViewModel, ShellViewModule>();
            Container.RegisterType<ICategoriesListViewModel, CategoriesListViewModel>();
            Container.RegisterType<INewCategoryViewModel, NewCategoryViewModel>();
            Container.RegisterType<IFeedViewModel, RssViewModel>();
            Container.RegisterType<IUrlBrowserViewModule, UrlBrowserViewModel>();

            var coreInitializer = Container.Resolve<CoreInitializer>();
            try
            {
                coreInitializer.Run();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

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

        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
