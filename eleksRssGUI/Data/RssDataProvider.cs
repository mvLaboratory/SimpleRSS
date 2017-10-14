using EleksRssCore;

namespace eleksRssGUI
{
    public class RssDataProvider : IDataProvider
    {
        public RssDataProvider(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void readData()
        {
            //_viewModel.ObservableRssItems.Add();
            var del = _viewModel.GetDelegate();
            var model = new RssItem("Sensation N" + (++i), "I am", "http", new Category("first", ""));
            del(model);
        }

        private BaseViewModel _viewModel;
        private static int i = 0;
    }
}
