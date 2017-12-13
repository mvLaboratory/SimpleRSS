using System;
using System.Text;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RssDataReaderUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _storage = new IStorageStub();

            _urlReader = new IDataReaderStub();
            _dataSaver = new IDataSaverFake(_storage);
            _dataProvider = new IDataProviderFake(_storage);

            _dataReader = new RssDataReader(_dataProvider, _dataSaver, _urlReader);
        }

        [TestMethod]
        public void Test_RssDataReader_Read()
        {
            _dataReader.Read();

            var result = _storage.Items;
        }

        private IUrlReader _urlReader;
        private IDataSaver _dataSaver;
        private IDataProvider _dataProvider;
        private IDataReader _dataReader;
        private IStorageStub _storage;
    }
}
