using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UrlBrowserModule
{
    public class UrlBrowserViewModel : BaseViewModel, INavigationAware
    {
        public override ICommand GetCommand(String commandName)
        {
            return null;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        public void OnNavigatedTo(NavigationContext navigationContext)
        { }
    }
}
