using Prism.Modularity;
using Prism.Regions;

namespace DesktopMainModule
{
    public class DesktopMainModule : IModule
    {
        public DesktopMainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
           _regionManager.RegisterViewWithRegion("MainRegion", typeof(MainWindowView));
        }

        private readonly IRegionManager _regionManager;
    }
}
