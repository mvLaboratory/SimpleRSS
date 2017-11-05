using Prism.Regions;
using GuiEnvironment;
using Prism.Modularity;

namespace CategoriesModule
{
    public class CategoriesModule: IModule
    {
        public CategoriesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("CategotiesViewRegion", typeof(CategoriesListView));
            _regionManager.RegisterViewWithRegion("NewCategoryRegion", typeof(NewCategoryView));
        }

        private readonly IRegionManager _regionManager;
    }
}
