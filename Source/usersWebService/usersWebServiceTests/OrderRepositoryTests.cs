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
    public class OrderRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(b => b.GetAll()).Returns(new List<DTOs.Order>());
        }

        [TestMethod()]

        public void TestGetById()
        {
            var orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Order("", "", 1, 1, "", "", 1));
        }

        [TestMethod()]

        public void TestCreateOrder()
        {
            Mock<IOrderRepository> ordRep = new Mock<IOrderRepository>();
            var order = new OrderRepository(ordRep.Object);
            Order orders = new Order();
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            Mock<IOrderRepository> ordRep = new Mock<IOrderRepository>();
            var order = new OrderRepository(ordRep.Object);
            Order orders = new Order();
        }

        [TestMethod()]

        public void TestSave()
        {
            Mock<IOrderRepository> ordRep = new Mock<IOrderRepository>();
        }

    }
}