using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingSample.Models.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        [DataRow("9.99")]
        [DataRow("$200.54")] // Works with US currency only
        [DataRow("0")]
        [DataRow(".29")]
        [DataRow("0.79")]
        [DataRow("99999999999")]
        public void IsValidPrice_ValidPrice_ReturnsTrue(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("Five")]
        [DataRow("3 and 5 cents")]
        [DataRow("5 dollars")]
        [DataRow("2.35.764")]
        [DataRow("$234.26$")]
        [DataRow("2354$")]
        [DataRow("3,000")]
        [DataRow("2,456.8")]
        public void IsValidPrice_InValidPrice_ReturnFalse(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsFalse(result);
        }
    }
}