using System;
using System.Windows.Input;
using GuiEnvironment;
using DesktopMainModule;
using Prism.Events;
using EleksRssCore;
using NLog;

namespace CategoriesModule
{
    public class CategoriesListViewModel : BaseViewModel, ICategoriesListViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }
        public ICommand OpenNewCategoryTabCommand { get; set; }
        public ICommand SelectCategoryCommand { get; set; }

        public CategoriesListViewModel(IEventAggregator eventAggregator, ObservableCategories categotiesList)
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
                _logger.Error("SelectCategory: param is not a Category");
                throw new ArgumentException("papam");
            }

            GuiManager.setCurrentCategory((Category) @params);
            _eventAggregator.GetEvent<UpdateRequestEvent>().Publish(true);
        }

        private IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
