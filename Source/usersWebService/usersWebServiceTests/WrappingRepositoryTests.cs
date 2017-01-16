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
    public class WrappingRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var wrappingMock = new Mock<IWrapperRepository>();
            wrappingMock.Setup(b => b.GetAll()).Returns(new List<DTOs.Wrapping>());
        }

        [TestMethod()]

        public void TestGetById()
        {
            var wrappingMock = new Mock<IWrapperRepository>();
            wrappingMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Wrapping(1, 1, "", 1 ,"", 1, 1));
        }

        [TestMethod()]

        public void TestCreateWrapping()
        {
            Mock<IWrapperRepository> wrapRep = new Mock<IWrapperRepository>();
            var wrap = new WrapperRepository(wrapRep.Object);
            Wrapping wraps = new Wrapping();
        }

        [TestMethod()]
        public void UpdateWrappingTest()
        {
            Mock<IWrapperRepository> wrapRep = new Mock<IWrapperRepository>();
            var wrap = new WrapperRepository(wrapRep.Object);
            Wrapping wraps = new Wrapping();
        }

        [TestMethod()]

        public void TestSave()
        {
            Mock<IWrapperRepository> wrapRep = new Mock<IWrapperRepository>();
        }

    }
}