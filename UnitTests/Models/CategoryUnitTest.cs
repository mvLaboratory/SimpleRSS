using System;
using EleksRssCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CategoryUnitTest
    {
        [TestMethod]
        public void ToStringEmptyObjectTest()
        {
            var testObject = new Category();
            var executionResult = testObject.ToString();
            var expectedResult = String.Empty;
            Assert.AreEqual(executionResult, expectedResult);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var testObject = new Category(2, "name", "url");
            var executionResult = testObject.ToString();
            var expectedResult = "name";
            Assert.AreEqual(executionResult, expectedResult);
        }

        [TestMethod]
        public void ConstructorHugeId()
        {
            var testObject = new Category(9999999999999, "name", "url");
            var executionResult = testObject.ToString();
            var expectedResult = "name";
            Assert.AreEqual(executionResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenIdIsLessThanZero()
        {
            var testObject = new Category(-1, "name", "url");
        }
    }
}
