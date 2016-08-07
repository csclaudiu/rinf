using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wAPI.Controllers;
using BusinessModels;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace wAPI.Tests
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void GetAll()
        {
            var mock = new MockProductRepository();
            var controller = new ProductController(mock);

            var result = controller.Get() as OkNegotiatedContentResult<List<Product>>;
            var theCollectionReturned = result.Content as List<Product>;
            Assert.AreEqual(mock.dummy.Count, theCollectionReturned.Count);
        }
    }
}
