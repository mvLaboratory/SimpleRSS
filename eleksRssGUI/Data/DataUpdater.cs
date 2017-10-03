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
        public DataUpdater()
        {
            _itemsForUpdate = new List<ObservableCollection<IModel>>();
        }

        public void addItemForUpdate(ObservableCollection<IModel> item)
        {
            _itemsForUpdate.Add(item);
        }

        async public void Start()
        {
            await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                await Task.Delay(1000);
            }
        }

        private List<ObservableCollection<IModel>> _itemsForUpdate;
    }
}
