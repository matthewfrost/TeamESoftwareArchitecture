using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CacheTest
{
    [TestClass]
    public class cacheTests
    {
        [TestMethod]
        public void productsTest()
        {
            //A way it should work

            cache.productsEntities2 db = new cache.productsEntities2();
            db.products.Select();

            var test1 = db.products;

            IEnumerable<testProducts> testing = test1.Select(o => new testProducts
            {
                productid = o.productid,

                productname = o.productname,

                productdescription = o.productdescription,

                categoryid = o.categoryid,

                categoryname = o.categoryname,

                brandid = o.brandid,

                minprice = o.minprice,

                maxprice = o.maxprice,
            });

            Assert.Equals(testing.Count(), 17);

        }

        [TestMethod]
        public void giftwrappingTest()
        {
            //A way it should work

            cache.productsEntities2 db = new cache.productsEntities2();
            db.wrappings.Select();

            var test1 = db.wrappings;

            IEnumerable<testWrapping> testing = test1.Select(o => new testWrapping
            {
                id = o.id,

                typeid = o.typeid,

                typename = o.typename,

                rangeid = o.rangeid,

                rangename = o.rangename,

                price = o.price,

                size = o.size,
            });

            Assert.Equals(testing.Count(), 1);


        }
    }
}
