using Prism.Events;
using System.Threading.Tasks;

namespace DesktopMainModule
{
    public class DataUpdater
    {
        public DataUpdater(IEventAggregator eventAggregator, RssDataProvider dataProvider)
        {
            _eventAggregator = eventAggregator;
            _dataProvider = dataProvider;
        } 

        async public void Start()
        {
             await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                var newItem = _dataProvider.readRssItems();
                _eventAggregator.GetEvent<RssItemsListChangedEvent>().Publish(newItem);
                await Task.Delay(2000);
            }
        }

        private IDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;
    }
}
