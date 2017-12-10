using System.Threading.Tasks;

namespace EleksRssCore
{
    public class CoreInitializer
    {
        public CoreInitializer(CoreInitializerParmeters coreParameters)
        {
            _coreParameters = coreParameters;
        }

        async public void Run()
        {
            await Task.Run(() => applicationRoutine());
        }

        private async void applicationRoutine()
        {
            while (true)
            {
                _coreParameters.DataReader.Read();
                await Task.Delay(ConfigurationProvider.UpdateInterval);
            }
        }

        private readonly CoreInitializerParmeters _coreParameters;
    }
}
