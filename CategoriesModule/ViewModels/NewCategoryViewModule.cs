using EleksRssCore;
using GuiEnvironment;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CategoriesModule
{
    public class NewCategoryViewModule : BaseViewModel
    {
        public String Name { get; set; }
        public String URL { get; set; }
        public ICommand SaveCategoryCommand { get; set; }

        public NewCategoryViewModule(IEventAggregator eventAggregator, IDataSaver dataSaver)
        {
            _eventAggregator = eventAggregator;
            _dataSaver = dataSaver;

            SaveCategoryCommand = new RelayCommand(saveCategory);
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private void saveCategory(object @params)
        {
            var newCategory = new Category(Name, URL);
            _dataSaver.saveCategory(newCategory);

            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(0);
            _eventAggregator.GetEvent<CategoriesListChangedEvent>().Publish(newCategory);
        }

        private IEventAggregator _eventAggregator;
        private IDataSaver _dataSaver;
    }
}
