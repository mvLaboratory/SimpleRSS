﻿using System;
using System.Text;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RssDataSaverUnitTest
    {
        [TestMethod]
        public void Test_RssDataReader_Read_Null()
        {
            RssDataReader.Read(null, null);
        }
    }
}
