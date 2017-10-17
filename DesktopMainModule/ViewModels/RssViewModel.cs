using System;
using EleksRssCore;
using System.Threading.Tasks;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; set; }
        public ObservableRssItems ObservableRssItems { get; set; }

        public RssViewModel(IEventAggregator eventAggregator, ObservableRssItems rssItemsList, ObservableCategories categotiesList)
        {
            ObservableCategories = categotiesList;
            ObservableRssItems = rssItemsList;

            _eventAggregator = eventAggregator;
            RssItemsListChangedEvent rssItemsListChangedEvent = eventAggregator.GetEvent<RssItemsListChangedEvent>();
            if (_subscriptionToken != null)
            {
                rssItemsListChangedEvent.Unsubscribe(_subscriptionToken);
            }
            _subscriptionToken = rssItemsListChangedEvent.Subscribe(ObservableRssItems.RssItemsListChangedHandler, ThreadOption.UIThread, false, ObservableRssItems.RssItemsListEventFilter);
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
