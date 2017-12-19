using System;
using Prism.Events;
using System.Windows.Input;
using Prism.Regions;
using Microsoft.Practices.Unity;
using GuiEnvironment;

namespace DesktopMainModule
{
    public class RssViewModel : BaseViewModel, IFeedViewModel
    {
        public ObservableRssItems ObservableRssItems { get; private set; }
        public Int32 SelectedTabIndex {  get; set; }
        public Int32 WindowHeight {
            get
            {
                return _windowHeight;
            }
            set
            {
                _windowHeight = value;
            }
        }

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
            WindowHeight = 675;
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
        private Int32 _windowHeight;
    }
}
