using GuiEnvironment;
using Prism.Events;
using System;
using System.Windows.Input;

namespace PagingModule
{
    public class PagingViewModule : BaseViewModel, IPagingViewModule
    {
        public string PagingText
        {
            get
            {
                return _pagingText;
            }

            set {
                _pagingText = value;
            }

        }

        public PagingViewModule(IEventAggregator eventAggregator) 
        {
            _eventAggregator = eventAggregator;

            PagesChangedEvent pagesChangedEvent = eventAggregator.GetEvent<PagesChangedEvent>();
            _subscriptionToken = pagesChangedEvent.Subscribe(pagesChangesEventHandler, ThreadOption.UIThread, false, pagesChangesEventFilter);
        }

        public void pagesChangesEventHandler(PagesDataStructure pages)
        {
            PagingText = string.Format("Page {0}", pages);
        }

        public bool pagesChangesEventFilter(PagesDataStructure param)
        {
            return true;
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private String _pagingText;
        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
