using EleksRssCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eleksRssGUI
{
    class DataUpdater
    {
        public DataUpdater(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        } 

        async public void Start()
        {
             await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                _dataProvider.readData();
                await Task.Delay(1000);
            }
        }

        private IDataProvider _dataProvider;
    }
}
