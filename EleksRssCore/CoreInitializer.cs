using EleksRssCore.Utils;
using System.Threading.Tasks;

namespace EleksRssCore
{
    public class CoreInitializer
    {
        public CoreInitializer()
        {
            _storageManager = new StorageManager();
        }

        async public void Run()
        {
            await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                RssDataReader.Read(_storageManager);
                await Task.Delay(ConfigurationProvider.UpdateInterval);
            }
        }

        private readonly StorageManager _storageManager;
    }
}
