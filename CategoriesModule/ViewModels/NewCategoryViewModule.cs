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
        public ICommand SaveCategoryCommand { get; set; }

        public NewCategoryViewModule(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCategoryCommand = new RelayCommand(saveCategory);
        }

        public override ICommand GetCommand(string commandName)
        {
            return null;
        }

        private void saveCategory(object @params)
        {
            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(0);
        }

        private IEventAggregator _eventAggregator;
    }
}
