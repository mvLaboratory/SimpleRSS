using System.Threading.Tasks;

namespace EleksRssCore
{
    public class CoreInitializer
    {
        public CoreInitializer()
        {
            _storageManager = new StorageManager();
            _dataSaver = new RssDataSaver(_storageManager);
            _dataProvider = new RssDataProvider(_storageManager);
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

        private readonly StorageManager _storageManager;
        private readonly IDataSaver _dataSaver;
        private readonly IDataProvider _dataProvider;
    }
}
