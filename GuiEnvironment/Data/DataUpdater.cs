using Prism.Events;
using System.Threading.Tasks;
using EleksRssCore;
using GuiEnvironment;

namespace GuiEnvironment
{
    public class DataUpdater: IDataUpdater
    {
        public DataUpdater(IEventAggregator eventAggregator, IDataProvider dataProvider)
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
                var itemsList = _dataProvider.readRssItems();
                _eventAggregator.GetEvent<RssItemsListChangedEvent>().Publish(itemsList);
                await Task.Delay(ConfigurationProvider.UpdateInterval);
            }
        }

        private IDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;
    }
}
