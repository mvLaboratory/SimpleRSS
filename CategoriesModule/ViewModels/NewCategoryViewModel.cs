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
    public class NewCategoryViewModel : BaseViewModel, INewCategoryViewModel
    {
        public String Name { get; set; }
        public String URL { get; set; }
        public ICommand SaveCategoryCommand { get; set; }
        public ICommand CancelCategoryCommand { get; set; }

        public NewCategoryViewModel(IEventAggregator eventAggregator, IDataSaver dataSaver)
        {
            _eventAggregator = eventAggregator;
            _dataSaver = dataSaver;

            SaveCategoryCommand = new RelayCommand(saveCategory);
            CancelCategoryCommand = new RelayCommand(cancel);
        }

        private void saveCategory(object @params)
        {
            var newCategory = new Category(Name, URL);
            _dataSaver.saveCategory(newCategory);

            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(0);
            _eventAggregator.GetEvent<CategoriesListChangedEvent>().Publish(newCategory);

            GuiManager.setCurrentCategory(newCategory);
           _eventAggregator.GetEvent<UpdateRequestEvent>().Publish(true);
        }

        private void cancel(object @params)
        {
            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(0);
        }

        private IEventAggregator _eventAggregator;
        private IDataSaver _dataSaver;
    }
}
