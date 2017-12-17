namespace EleksRssCore
{
    public struct CoreInitializerParmeters
    {
        public IStorageManager StorageManager { get; set; }
        public IDataSaver DataSaver { get; set; }
        public IDataProvider DataProvider { get; set; }
        public IDataReader DataReader { get; set; }

        public CoreInitializerParmeters(IStorageManager storageManager, IDataSaver dataSaver, IDataProvider dataProvider, IDataReader rssDataReader)
        {
            StorageManager = storageManager;
            DataSaver = dataSaver;
            DataProvider = dataProvider;
            DataReader = rssDataReader;
        }
    }
}
