using EleksRssCore;
using System.Collections.Generic;

namespace DesktopMainModule
{
    public class RssDataProvider : IDataProvider
    {
        public RssDataProvider(RssViewModel viewModel, StorageManager storageManager)
        {
            _viewModel = viewModel;
            _storageManager = storageManager;
        }

        public List<RssItem> readRssItems()
        {
            return _storageManager.readRssItems();
        }

        private BaseViewModel _viewModel;
        private StorageManager _storageManager; 
    }
}
