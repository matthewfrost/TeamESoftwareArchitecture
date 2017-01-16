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
    public class UserRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var userMock = new Mock<IUserRepository>();
            userMock.Setup(b => b.GetAll()).Returns(new List<DTOs.User>());
        }

        [TestMethod()]

        public void TestGetById()
        {
            var userMock = new Mock<IUserRepository>();
            userMock.Setup(b => b.GetById(It.IsAny<int>())).Returns(new DTOs.User(1, "", ""));
        }

        [TestMethod()]

        public void TestCreateUser()
        {
            Mock<IUserRepository> userRep = new Mock<IUserRepository>();
            var user = new UserRepository(userRep.Object);
            User users = new User();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            Mock<IUserRepository> userRep = new Mock<IUserRepository>();
            var user = new UserRepository(userRep.Object);
            User users = new User();
        }

        [TestMethod()]

        public void TestSave()
        {
            Mock<IUserRepository> prodRep = new Mock<IUserRepository>();
        }

    }
}