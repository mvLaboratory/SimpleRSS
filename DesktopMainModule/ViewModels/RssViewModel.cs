using System;
using EleksRssCore;
using System.Threading.Tasks;
using Prism.Events;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel
    {
        public RssViewModel(IEventAggregator eventAggregator)
        {
            ObservableCategories = new ObservableCategories();
            ObservableRssItems = new ObservableRssItems();

            _eventAggregator = eventAggregator;
            RssItemsListChangedEvent rssItemsListChangedEvent = eventAggregator.GetEvent<RssItemsListChangedEvent>();
            if (_subscriptionToken != null)
            {
                rssItemsListChangedEvent.Unsubscribe(_subscriptionToken);
            }
            _subscriptionToken = rssItemsListChangedEvent.Subscribe(RssItemsListChangedHandler, ThreadOption.UIThread, false, RssItemsListEventFilter);



            //new StorageManager();
            //updateItems();
        }

        public bool RssItemsListEventFilter(RssItem item)
        {
            return true;
        }

        public void RssItemsListChangedHandler(RssItem item)
        {
            ObservableRssItems.Add(item);
        }

        public override TestDelegate GetDelegate()
        {
            return new TestDelegate(test);
        }

        async Task updateItems()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                ObservableRssItems.Add(new RssItem("Sensation N" + i, "I am", "http", new Category("first", "")));
            }
        }

        public void test(IModel model)
        {
            //ObservableRssItems.Add(model);
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
