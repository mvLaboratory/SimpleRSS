using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace DesktopMainModule
{
    public class DesktopMainModule : IModule
    {
        public DesktopMainModule(IRegionManager regionManager, DataUpdater updater, IUnityContainer container)
        {
            _regionManager = regionManager;
            _updater = updater;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IDataProvider, RssDataProvider>();
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(MainWindowView));
            _updater.Start();
        }

        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        private readonly DataUpdater _updater;
    }
}
