using System;
using Prism.Events;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; set; }
        public ObservableRssItems ObservableRssItems { get; set; }
        public ICommand RssItemDbClick
        {
            get {
                if (_rssItemDbClick == null)
                {
                    _rssItemDbClick = new RelayCommand(openBrowser);
                }

                return _rssItemDbClick;
            }
        }

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

        public override ICommand GetCommand(String commandName)
        {
            Dictionary<String, ICommand> commandDictionary = new Dictionary<String, ICommand>();
            commandDictionary.Add("RssItemDbClick", RssItemDbClick);

            return commandDictionary.FirstOrDefault(item => item.Key.Equals(commandName)).Value;
        }

        private void openBrowser(object url)
        {
            MessageBox.Show("Do you want to close t");
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
        private ICommand _rssItemDbClick;
    }
}
