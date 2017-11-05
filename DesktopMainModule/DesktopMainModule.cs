using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using GuiEnvironment;

namespace DesktopMainModule
{
    public class DesktopMainModule : IModule
    {
        public DesktopMainModule(IRegionManager regionManager, IDataUpdater updater)
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
        private readonly IDataUpdater _updater;
    }
}
