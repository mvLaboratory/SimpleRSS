using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GuiEnvironment;
using Prism.Events;

namespace UrlBrowserModule
{
    public class UrlBrowserViewModel : BaseViewModel
    {
        public ICommand BackToNewsCommand { get; set; }
        public String NewsURL { get; set; }

        public UrlBrowserViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UrlChangedEvent urlChangedEvent = eventAggregator.GetEvent<UrlChangedEvent>();
            _subscriptionToken = urlChangedEvent.Subscribe(UrlChangedEventHandler, ThreadOption.UIThread, false, RssItemsListEventFilter);
            BackToNewsCommand = new RelayCommand(backToNews);
        }

        public override ICommand GetCommand(String commandName)
        {
            return null;
        }

        public void UrlChangedEventHandler(String url)
        {
            NewsURL = url;
        }

        public bool RssItemsListEventFilter(String url)
        {
            return true;
        }

        private void backToNews(object @params)
        {
            NewsURL = "";
            _eventAggregator.GetEvent<BackToNewsEvent>().Publish(0);
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
