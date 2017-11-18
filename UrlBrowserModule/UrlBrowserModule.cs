using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace UrlBrowserModule
{
    public class UrlBrowserModule : IModule
    {
        public UrlBrowserModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("UrlBrowserRegion", typeof(UrlBrowserView));
        }

        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
    }
}
