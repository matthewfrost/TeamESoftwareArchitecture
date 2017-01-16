using Microsoft.VisualStudio.TestTools.UnitTesting;
using usersWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Repositories1;

namespace usersWebService.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var prodMock = new Mock<IProductrepository>();
            prodMock.Setup(b => b.GetAll()).Returns(new List<DTOs.Product>());
        }

        [TestMethod()]

        public void TestGetById()
        {
            var prodMock = new Mock<IProductrepository>();
            prodMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Product(1, "", 0, "", 0, "", "", "", 0, true, DateTime.Now, ""));
        }

        [TestMethod()]

        public void TestCreateProduct()
        {
            Mock<IProductrepository> prodRep = new Mock<IProductrepository>();
            var prod = new ProductRepository(prodRep.Object);
            Product prods = new Product();
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            Mock<IProductrepository> prodRep = new Mock<IProductrepository>();
            var prod = new ProductRepository(prodRep.Object);
            Product prods = new Product();
        }

        [TestMethod()]

        public void TestSave()
        {
            Mock<IProductrepository> prodRep = new Mock<IProductrepository>();
        }

    }
}