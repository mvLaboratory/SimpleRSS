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

        public ICommand PageChangeCommand { get; set; }

        public PagingViewModule(IEventAggregator eventAggregator) 
        {
            _eventAggregator = eventAggregator;

            PageChangeCommand = new RelayCommand(SelectCategory);

            PagesChangedEvent pagesChangedEvent = eventAggregator.GetEvent<PagesChangedEvent>();
            _subscriptionToken = pagesChangedEvent.Subscribe(pagesChangesEventHandler, ThreadOption.UIThread, false, pagesChangesEventFilter);
        }

        private void SelectCategory(object @params)
        {
            Int32 pageOffset = 0;

            try
            {
                pageOffset = Int32.Parse(@params.ToString());
            }
            catch(Exception ex)
            {
                //TODO:: Handle exceoption; creatre a logger class
            }
            
            GuiManager.setCurrentPage(pageOffset);
            _eventAggregator.GetEvent<UpdateRequestEvent>().Publish(true);
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
