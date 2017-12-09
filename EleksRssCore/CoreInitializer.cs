using System;
using System.Threading.Tasks;

namespace EleksRssCore
{
    public class CoreInitializer
    {
        //TODO:init from Unity, add reader
        public CoreInitializer(IStorageManager storageManager, IDataSaver dataSaver, IDataProvider dataProvider)
        {
            _storageManager = storageManager;
            _dataSaver = dataSaver;
            _dataProvider = dataProvider;
        }

        async public void Run()
        {
            await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                RssDataReader.Read(_dataProvider, _dataSaver);
                await Task.Delay(ConfigurationProvider.UpdateInterval);
            }
        }

        private readonly IStorageManager _storageManager;
        private readonly IDataSaver _dataSaver;
        private readonly IDataProvider _dataProvider;
    }
}
