using System;
using System.Text;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

            var _cat1 = new Category(1, "Category1", "url1");
            var _cat2 = new Category(2, "Category2", "url2");
            var _item1 = new RssItem(1, DateTime.MinValue, "title1", "author1", "url1", _cat1);
            var _item2 = new RssItem(2, DateTime.Now, "title2", "author2", "url2", _cat2);
            var _item3 = new RssItem(3, DateTime.MaxValue, "title3", "author3", "url3", _cat1);
            var _item4 = new RssItem(4, DateTime.Parse("01/01/01 12:00:00 AM"), "Item 1", "", null, _cat1);
            var _item5 = new RssItem(5, DateTime.Parse("01/01/01 12:00:00 AM"), "Item 2", "", null, _cat2);
            var expectedResult = new List<RssItem> { _item1, _item2, _item3, _item4, _item5 };

            Assert.AreEqual(result.Count, expectedResult.Count);
            CollectionAssert.AreEqual(result, expectedResult);
        }

        private IUrlReader _urlReader;
        private IDataSaver _dataSaver;
        private IDataProvider _dataProvider;
        private IDataReader _dataReader;
        private IStorageStub _storage;
    }
}
