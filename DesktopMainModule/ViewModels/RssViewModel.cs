using System;
using Prism.Events;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using Microsoft.Practices.Unity;
using UrlBrowserModule;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }
        public ObservableRssItems ObservableRssItems { get; private set; }
        public int SelectedTabIndex {  get; set; }
        public String NewsURL { get; set; }
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
        public ICommand BackToNewsCommand { get; set; }

        public RssViewModel(IEventAggregator eventAggregator, ObservableRssItems rssItemsList, ObservableCategories categotiesList, IRegionManager regionManager, IUnityContainer container)
        {
            ObservableCategories = categotiesList;
            ObservableRssItems = rssItemsList;

            _eventAggregator = eventAggregator;
            RssItemsListChangedEvent rssItemsListChangedEvent = eventAggregator.GetEvent<RssItemsListChangedEvent>();
            _subscriptionToken = rssItemsListChangedEvent.Subscribe(ObservableRssItems.RssItemsListChangedHandler, ThreadOption.UIThread, false, ObservableRssItems.RssItemsListEventFilter);

            _regionManager = regionManager;
            _container = container;

            BackToNewsCommand = new RelayCommand(backToNews);

            SelectedTabIndex = 0;
        }

        public override ICommand GetCommand(String commandName)
        {
            Dictionary<String, ICommand> commandDictionary = new Dictionary<String, ICommand>();
            commandDictionary.Add("RssItemDbClick", RssItemDbClick);

            return commandDictionary.FirstOrDefault(item => item.Key.Equals(commandName)).Value;
        }

        private void openBrowser(object url)
        {
            NewsURL = url.ToString();
            SelectedTabIndex = 1;
        }

        private void backToNews(object @params)
        {
            NewsURL = "";
            SelectedTabIndex = 0;
        }

        private SubscriptionToken _subscriptionToken;
        private IEventAggregator _eventAggregator;      
        private ICommand _rssItemDbClick;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
    }
}
