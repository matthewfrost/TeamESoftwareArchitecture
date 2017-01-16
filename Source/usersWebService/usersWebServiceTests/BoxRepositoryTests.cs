using Microsoft.VisualStudio.TestTools.UnitTesting;
using usersWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories1;
using Moq;
using DTOs;


namespace usersWebService.Tests
{
    [TestClass()]
    public class BoxRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var boxMock = new Mock<IBoxRepository>();
            boxMock.Setup(b => b.GetAll()).Returns(new List<DTOs.Box>());
        }

        [TestMethod()]

        public void TestGetById()
        {
            var boxMock = new Mock<IBoxRepository>();
            boxMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Box(1,"",0,"",true,true));
        }

        [TestMethod()]

        public void TestCreateBox()
        {
            Mock<IBoxRepository> boxRep = new Mock<IBoxRepository>();
            var box = new BoxRepository(boxRep.Object);
            Box boxe = new Box();
        }

        [TestMethod()]
        public void UpdateBoxTest()
        {
            Mock<IBoxRepository> boxRep = new Mock<IBoxRepository>();
            var box = new BoxRepository(boxRep.Object);
            Box boxe = new Box();
        }

        [TestMethod()]

        public void TestGetItemsForBox()
        {
            Mock<IBoxRepository> boxMock = new Mock<IBoxRepository>();
            boxMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Box(1, "", 0, "", true, true));
        }

        [TestMethod()]

        public void TestSave()
        {
            Mock<IBoxRepository> boxMock = new Mock<IBoxRepository>();
        }

        [TestMethod()]

        public void Testbetween5and25()
        {
            Mock<IBoxRepository> boxMock = new Mock<IBoxRepository>();
            boxMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Box(1, "", 0, "", true, true));
        }

        [TestMethod()]

        public void Test10PercentMargin()
        {
            Mock<IBoxRepository> boxMock = new Mock<IBoxRepository>();
            boxMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.Box(1, "", 0, "", true, true));
        }
    }
}
