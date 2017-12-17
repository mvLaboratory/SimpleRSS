using System;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Models
{
    [TestClass]
    public class RssItemUnitTest
    {
        [TestMethod]
        public void TestRss_ToStringEmptyObject()
        {
            var testObject = new RssItem();
            var executionResult = testObject.ToString();
            var expectedResult = String.Empty;
            Assert.AreEqual(executionResult, expectedResult);
        }

        [TestMethod]
        public void TestRss_ToString()
        {
            Category cat = new Category();
            var testObject = new RssItem("title", "author", "url", cat);
            String executionResult = testObject.ToString();
            String expectedResult = "title";
            Assert.AreEqual(executionResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRss_Constructor_WhenIdIsLessThanZero()
        {
            Category cat = new Category();
            var testObject = new RssItem(-1, DateTime.Now, "author", "name", "url", cat);
        }
        public void TestMethod1()
        {
        }
    }
}
