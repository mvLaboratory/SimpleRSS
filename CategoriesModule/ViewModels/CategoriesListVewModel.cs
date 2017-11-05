using System.Windows.Input;
using GuiEnvironment;
using DesktopMainModule;
using Prism.Events;

namespace CategoriesModule
{
    public class CategoriesListVewModel : BaseViewModel
    {
        public ObservableCategories ObservableCategories { get; private set; }
        public ICommand OpenNewCategoryTabCommand { get; set; }

        public CategoriesListVewModel(IEventAggregator eventAggregator, ObservableCategories categotiesList)
        {
            ObservableCategories = categotiesList;
            _eventAggregator = eventAggregator;

            OpenNewCategoryTabCommand = new RelayCommand(openNewCategoryTab);
        }

        private void openNewCategoryTab(object @params)
        {
            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(2);
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private IEventAggregator _eventAggregator;
    }
}
