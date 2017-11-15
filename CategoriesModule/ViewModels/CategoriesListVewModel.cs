using System;
using System.Windows.Input;
using GuiEnvironment;
using DesktopMainModule;
using Prism.Events;
using EleksRssCore;

namespace CategoriesModule
{
    public class CategoriesListVewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }
        public ICommand OpenNewCategoryTabCommand { get; set; }
        public ICommand SelectCategoryCommand { get; set; }

        public CategoriesListVewModel(IEventAggregator eventAggregator, ObservableCategories categotiesList)
        {
            ObservableCategories = categotiesList;
            _eventAggregator = eventAggregator;

            OpenNewCategoryTabCommand = new RelayCommand(openNewCategoryTab);
            SelectCategoryCommand = new RelayCommand(SelectCategory);

            CategoriesListChangedEvent categoriesListChangedEvent = eventAggregator.GetEvent<CategoriesListChangedEvent>();
            _subscriptionToken = categoriesListChangedEvent.Subscribe(ObservableCategories.CategoriesListChangedHandler, ThreadOption.UIThread, false, ObservableCategories.CategoriesListEventFilter);
        }

        private void openNewCategoryTab(object @params)
        {
            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(2);
        }

        private void SelectCategory(object @params)
        {
            if (! (@params is Category))
            {
                throw new ArgumentException("papam");
            }

            GuiManager.setCurrentCategory((Category) @params);
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
    }
}
