using System.Windows.Input;
using GuiEnvironment;
using DesktopMainModule;
using Prism.Events;

namespace CategoriesModule
{
    class CategoriesListVewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }

        public CategoriesListVewModel(IEventAggregator eventAggregator, ObservableCategories categotiesList)
        {
            ObservableCategories = categotiesList;
            _eventAggregator = eventAggregator;
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private SubscriptionToken _subscriptionToken;
        private IEventAggregator _eventAggregator;
    }
}
