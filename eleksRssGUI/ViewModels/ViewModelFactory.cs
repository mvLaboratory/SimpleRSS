
namespace eleksRssGUI
{
    class ViewModelFactory : IViewModelFactory
    {
        public BaseViewModel GetRssViewModel()
        {
            IDataProvider dataProvider = new RssDataProvider();
            BaseViewModel viewModel = new RssViewModel(dataProvider);

            DataUpdater updater = new DataUpdater();
            //updater.addItemForUpdate(viewModel.ObservableCategories);
            updater.Start();

            return viewModel;
        }
    }
}
