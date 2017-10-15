using Prism.Modularity;
using Prism.Regions;

namespace DesktopMainModule
{
    public class DesktopMainModule : IModule
    {
        public DesktopMainModule(IRegionManager regionManager, DataUpdater updater)
        {
            _regionManager = regionManager;
            _updater = updater;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(MainWindowView));
            _updater.Start();
        }

        private readonly IRegionManager _regionManager;
        private readonly DataUpdater _updater;
    }
}
