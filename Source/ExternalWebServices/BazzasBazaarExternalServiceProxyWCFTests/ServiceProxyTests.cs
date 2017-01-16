using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazzasBazaarExternalServiceProxyWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FakeItEasy;

namespace BazzasBazaarExternalServiceProxyWCF.Tests
{
    [TestClass()]
    public class ServiceProxyTests
    {
        ServiceProxy proxy;
        BazzasBazaarService.StoreClient WCFClient;

        [TestInitialize]
        public void Initialise()
        {
            proxy = new ServiceProxy();
            WCFClient = A.Fake<BazzasBazaarService.StoreClient>();
        }

        [TestMethod()]
        public async Task BazzaBazaars_getAllCategoriesTestIsNotNull()
        {
            var categories = await proxy.getAllCategories();

            Assert.IsNotNull(categories);
        }
                
        [TestMethod()]
        public async Task BazzaBazaars_getCategoryByIdTestIsNotNull()
        {
            var category = await proxy.getCategoryById(1);

            Assert.IsNotNull(category);
        }

        [TestMethod()]
        public async Task BazzaBazaars_getCategoryByIdTestIdDoesntExist()
        {
            var category = await proxy.getCategoryById(999);

            Assert.IsNull(category);
        }

        [TestMethod()]
        public async Task BazzaBazaars_getProductByIdTestIsNotNull()
        {
            var product = await proxy.getProductById(1);

            Assert.IsNotNull(product);
        }

        [TestMethod()]
        public async Task BazzaBazaars_getProductByIdTestIdDoesntExist()
        {
            var product = await proxy.getProductById(999);

            Assert.IsNull(product);
        }

        [TestMethod()]
        public async Task BazzaBazaars_getOrderByIdTestIsNotNull()
        {
            var order = await proxy.getOrderById(1);

            Assert.IsNotNull(order);
        }

        [TestMethod()]
        public async Task BazzaBazaars_getOrderByIdTestIdDoesntExist()
        {
            var order = await proxy.getOrderById(999);

            Assert.IsNull(order);
        }

        //[TestMethod()]
        //public async Task BazzaBazaars_getFilteredProductsTestIsNotNull()
        //{
        //    var products = await proxy.getFilteredProducts();

        //    Assert.IsNotNull(products);

        //}

        //[TestMethod()]
        //public async Task BazzaBazaars_getFilteredProductsByIdTestWithInvalidParameters()
        //{
        //    var products = await proxy.getFilteredProducts();

        //    Assert.IsNull(products);

        //}
    }
}