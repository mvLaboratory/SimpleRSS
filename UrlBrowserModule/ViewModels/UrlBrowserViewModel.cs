using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GuiEnvironment;

namespace UrlBrowserModule
{
    public class UrlBrowserViewModel : BaseViewModel
    {
        public ICommand BackToNewsCommand { get; set; }
        public String NewsURL { get; set; }

        public UrlBrowserViewModel()
        {
            BackToNewsCommand = new RelayCommand(backToNews);
        }

        public override ICommand GetCommand(String commandName)
        {
            return null;
        }




        private void backToNews(object @params)
        {
            NewsURL = "";
            //SelectedTabIndex = 0;
        }

    }
}
