
namespace eleksRssGUI
{
    class ViewModelFactory : IViewModelFactory
    {
        public BaseViewModel GetRssViewModel()
        {
            IDataProvider dataProvider = new RssDataProvider();
            return new RssViewModel(dataProvider);
        }
    }
}
