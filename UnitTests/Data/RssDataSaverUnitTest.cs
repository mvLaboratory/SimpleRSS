using System;
using System.Text;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RssDataSaverUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_RssDataReader_Read_Null()
        {
            RssDataReader.Read(null, null);
            RssDataReader.Read(new IDataReaderFake(), null);
            RssDataReader.Read(null, new IDataSaverFake());
        }
    }
}
