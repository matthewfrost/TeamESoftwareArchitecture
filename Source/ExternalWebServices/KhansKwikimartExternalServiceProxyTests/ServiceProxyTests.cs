using Microsoft.VisualStudio.TestTools.UnitTesting;
using KhansKwikimartExternalServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using KhansKwikimartExternalServiceProxy.Responses;

namespace KhansKwikimartExternalServiceProxy.Tests
{
    [TestClass()]
    public class ServiceProxyTests
    {
        ServiceProxy proxy;
        ServiceInteraction serviceInteraction;

        [TestInitialize]
        public void Initialise()
        {
            serviceInteraction = A.Fake<ServiceInteraction>();
            proxy = new ServiceProxy(serviceInteraction);
        }

        [TestMethod]
        public void KhansKwikimartExternalServiceProxyConstructorSuccessfullyCreatesObject()
        {
            proxy = new ServiceProxy(serviceInteraction);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void KhansKwikimartExternalServiceProxyConstructorThrowsExceptionWithMissingServiceInteraction()
        {
            proxy = new ServiceProxy(null);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByRangeReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.RangeDTO>>(new List<DTO.RangeDTO> { new DTO.RangeDTO { Id = 1, Name = "Test Name", Description = "Test Description" } });
            A.CallTo(() => serviceInteraction.GetGiftWrappingByRangeFromServer()).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> rangeServiceResponse = await proxy.GetGiftWrappingByRange();

            var proxyRange = rangeServiceResponse.target;

            Assert.AreNotEqual(0, proxyRange.Count());
            Assert.IsTrue(rangeServiceResponse.successful);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByRangeReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.RangeDTO>>(new List<DTO.RangeDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingByRangeFromServer()).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> rangeServiceResponse = await proxy.GetGiftWrappingByRange();
            
            Assert.IsFalse(rangeServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, rangeServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByRangeReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetGiftWrappingByRangeFromServer()).Throws(new Exception());

            KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> rangeServiceResponse = await proxy.GetGiftWrappingByRange();

            Assert.IsFalse(rangeServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, rangeServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByTypeReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.TypeDTO>>(new List<DTO.TypeDTO> { new DTO.TypeDTO { Id = 1, Name = "Test Name", Description = "Test Description" } });
            A.CallTo(() => serviceInteraction.GetGiftWrappingByTypeFromServer()).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> typeServiceResponse = await proxy.GetGiftWrappingByType();

            var proxyType = typeServiceResponse.target;

            Assert.AreNotEqual(0, proxyType.Count());
            Assert.IsTrue(typeServiceResponse.successful);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByTypeReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.TypeDTO>>(new List<DTO.TypeDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingByTypeFromServer()).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> typeServiceResponse = await proxy.GetGiftWrappingByType();

            Assert.IsFalse(typeServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, typeServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingByTypeReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetGiftWrappingByTypeFromServer()).Throws(new Exception());

            KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> typeServiceResponse = await proxy.GetGiftWrappingByType();

            Assert.IsFalse(typeServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, typeServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsPopulatedListAndSuccessWithValidParameters()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO> { new DTO.ProductDTO { Id = 1, RangeName = "Test Range", TypeName = "Test Type" } });
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 0, 100, 0, 100);

            var proxyProduct = productServiceResponse.target;

            Assert.AreNotEqual(0, proxyProduct.Count());
            Assert.IsTrue(productServiceResponse.successful);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidTypeId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(999, 1, 0, 100, 0, 100);
            
            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidRangeId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 999, 0, 100, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidMinPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 999, 100, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }
        
        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidMaxPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 0, 0, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidMinSize()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 0, 100, 999, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWithInvalidMaxSize()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Returns(result);

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 0, 100, 0, 0);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task KhansKwikimartExternalServiceProxyGetGiftWrappingReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetGiftWrappingFromServer(A<int>.Ignored, A<int>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored, A<decimal>.Ignored)).Throws(new Exception());

            KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetGiftWrapping(1, 1, 0, 100, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }
        
    }
}