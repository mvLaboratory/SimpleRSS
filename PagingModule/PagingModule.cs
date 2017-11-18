using Prism.Modularity;
using Prism.Regions;

namespace PagingModule
{
    public class PagingModule : IModule
    {
        public PagingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("PagingRegion", typeof(PagingView));
        }

        private readonly IRegionManager _regionManager;
    }
}
