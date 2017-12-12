using System;
using System.Text;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RssDataSaverUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _urlReader = new IDataReaderStub();
            _dataSaver = new IDataSaverFake();
            _dataProvider = new IDataProviderFake();

            _dataReader = new RssDataReader(_dataProvider, _dataSaver, _urlReader);
        }

        [TestMethod]
        public void Test_RssDataReader_Read()
        {
            _dataReader.Read();
        }

        private IUrlReader _urlReader;
        private IDataSaver _dataSaver;
        private IDataProvider _dataProvider;
        private IDataReader _dataReader;
    }
}
