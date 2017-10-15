using EleksRssCore;

namespace DesktopMainModule
{
    public class RssDataProvider : IDataProvider
    {
        public RssDataProvider(RssViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public RssItem readData()
        {
            //_viewModel.ObservableRssItems.Add();
            //var del = _viewModel.GetDelegate();
            return new RssItem("Sensation N" + (++i), "I am", "http", new Category("first", ""));
            //del(model);
        }

        private BaseViewModel _viewModel;
        private static int i = 0;
    }
}
