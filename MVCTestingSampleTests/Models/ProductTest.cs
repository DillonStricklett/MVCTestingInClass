using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingSampleTests.Models
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Name_SetToNull_ThrowsArgumentNullException()
        {
            Product p = new Product();

            Assert.ThrowsException<ArgumentNullException>
                (
                    () => p.Name = null
                );
        }
    }
}
