using Prism.Events;
using System.Threading.Tasks;
using EleksRssCore;
using System;

namespace GuiEnvironment
{
    public class DataUpdater: IDataUpdater
    {
        public DataUpdater(IEventAggregator eventAggregator, IDataProvider dataProvider)
        {
            _eventAggregator = eventAggregator;
            _dataProvider = dataProvider;

            UpdateRequestEvent updateRequestEvent = _eventAggregator.GetEvent<UpdateRequestEvent>();
            _subscriptionToken = updateRequestEvent.Subscribe(updateRequestEventHandler, ThreadOption.UIThread, false, UpdateRequestEventFilter);
        }

        async public void Start()
        {
            await Task.Delay(2000);
            await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                update();
                await Task.Delay(ConfigurationProvider.UpdateInterval);
            }
        }

        private void update()
        {
            var itemsList = _dataProvider.readRssItems();
            _eventAggregator.GetEvent<RssItemsListChangedEvent>().Publish(itemsList);
            _eventAggregator.GetEvent<PagesChangedEvent>().Publish(new PagesDataStructure());
        }

        private void updateRequestEventHandler(bool param)
        {
            update();
        }
        
        private bool UpdateRequestEventFilter(bool param)
        {
            return true;
        }

        private IDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
