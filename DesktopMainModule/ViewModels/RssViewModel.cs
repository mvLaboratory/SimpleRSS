using System;
using Prism.Events;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using Microsoft.Practices.Unity;
using GuiEnvironment;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel
    {
        public ObservableRssItems ObservableRssItems { get; private set; }
        public int SelectedTabIndex {  get; set; }
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


        public RssViewModel(IEventAggregator eventAggregator, ObservableRssItems rssItemsList, IRegionManager regionManager, IUnityContainer container)
        {
            ObservableRssItems = rssItemsList;

            _eventAggregator = eventAggregator;
            RssItemsListChangedEvent rssItemsListChangedEvent = eventAggregator.GetEvent<RssItemsListChangedEvent>();
            _subscriptionToken = rssItemsListChangedEvent.Subscribe(ObservableRssItems.RssItemsListChangedHandler, ThreadOption.UIThread, false, ObservableRssItems.RssItemsListEventFilter);

            ChangeTabEvent backToNewsEvent = eventAggregator.GetEvent<ChangeTabEvent>();
            _subscriptionToken = backToNewsEvent.Subscribe(changeTabEventHandler, ThreadOption.UIThread, false, changeTabEventFilter);

            _regionManager = regionManager;
            _container = container;

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
            _eventAggregator.GetEvent<UrlChangedEvent>().Publish(url.ToString());
            SelectedTabIndex = 1;
        }

        private void changeTabEventHandler(object prop)
        {
            if (!(prop is Int32))
            {
                throw new ArgumentException("Open tab property");
            }
            SelectedTabIndex = (Int32)prop;
        }

        public bool changeTabEventFilter(object prop)
        {
            return true;
        }

        private SubscriptionToken _subscriptionToken;
        private IEventAggregator _eventAggregator;      
        private ICommand _rssItemDbClick;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
    }
}
