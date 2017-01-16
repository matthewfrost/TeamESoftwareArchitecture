using Microsoft.VisualStudio.TestTools.UnitTesting;
using DodgeyDealersExternalServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using DodgeyDealersExternalServiceProxy.Responses;

namespace DodgeyDealersExternalServiceProxy.Tests
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
        public void DodgyDealersExternalServiceProxyConstructorSuccessfullyCreatesObject()
        {
            proxy = new ServiceProxy(serviceInteraction);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void DodgyDealersExternalServiceProxyConstructorThrowsExceptionWithMissingServiceIntegration()
        {
            proxy = new ServiceProxy(null);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllBrandsReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.BrandDTO>>(new List<DTO.BrandDTO> { new DTO.BrandDTO { Id = 1, Name = "Test Method", AvailableProductCount = 2 } });
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            var proxyBrand = brandsServiceResponse.target;

            Assert.AreNotEqual(0, proxyBrand.Count());
            Assert.IsTrue(brandsServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllBrandsReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.BrandDTO>>(new List<DTO.BrandDTO>());
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllBrandsReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Throws(new Exception());

            DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetBrandByIdReturnsSingleEntryAndSuccess()
        {
            var result = Task.FromResult(new DTO.BrandDTO { Id = 1, Name = "Test Method", AvailableProductCount = 2 } );
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(1);

            var proxyBrand = brandsServiceResponse.target;

            Assert.AreEqual(1, proxyBrand.Id);
            Assert.IsTrue(brandsServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetBrandByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.BrandDTO>(null);
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(999);

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetBrandByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            DodgyDealersServiceResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(1);

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllCategoriesReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.CategoryDTO>>(new List<DTO.CategoryDTO> { new DTO.CategoryDTO { Id = 1, Name = "Test Method", AvailableProductCount = 2, Description = "Test Description" } });
            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            var proxyCategories = categoriesServiceResponse.target;

            Assert.AreNotEqual(0, proxyCategories.Count());
            Assert.IsTrue(categoriesServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllCategoriesReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.CategoryDTO>>(new List<DTO.CategoryDTO>());
            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            Assert.IsFalse(categoriesServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoriesServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllCategoriesReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Throws(new Exception());

            DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            Assert.IsFalse(categoriesServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoriesServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetCategoryByIdReturnsSingleEntryAndSuccess()
        {
            var result = Task.FromResult(new DTO.CategoryDTO { Id = 1, Name = "Test Method", AvailableProductCount = 2 });
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(1);

            var proxyCategory = categoryServiceResponse.target;

            Assert.AreEqual(1, proxyCategory.Id);
            Assert.IsTrue(categoryServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetCategoryByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.CategoryDTO>(null);
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(999);

            Assert.IsFalse(categoryServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoryServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetCategoryByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            DodgyDealersServiceResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(1);

            Assert.IsFalse(categoryServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoryServiceResponse.message);
        }


        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllProductsReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO> { new DTO.ProductDTO { Id = 1, Name = "Test Method", Description = "Test Description" } });
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            var proxyProducts = productsServiceResponse.target;

            Assert.AreNotEqual(0, proxyProducts.Count());
            Assert.IsTrue(productsServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllProductsReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetAllProductsReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Throws(new Exception());

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductByIdReturnsSingleEntryAndSuccess()
        {
            var result = Task.FromResult(new DTO.ProductDTO { Id = 1, Name = "Test Method" });
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.ProductDTO> productServiceResponse = await proxy.GetProductById(1);

            var proxyProduct = productServiceResponse.target;

            Assert.AreEqual(1, proxyProduct.Id);
            Assert.IsTrue(productServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.ProductDTO>(null);
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.ProductDTO> productServiceResponse = await proxy.GetProductById(999);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            DodgyDealersServiceResponse<DTO.ProductDTO> productServiceResponse = await proxy.GetProductById(1);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsPopulatedListAndSuccessWithValidParameters()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO> { new DTO.ProductDTO { Id = 1, Name = "Test Name", Description = "Test Description" } });
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 0, 100);

            var proxyProduct = productServiceResponse.target;

            Assert.AreNotEqual(0, proxyProduct.Count());
            Assert.IsTrue(productServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidCategoryId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(999, "Screen Protectors", 1, 0, 100);
            
            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidCategoryName()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Test", 1, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidBrandId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 999, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidMinPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 999, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidMaxPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 0, 0);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetProductReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Throws(new Exception());

            DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> productServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 0, 100);

            Assert.IsFalse(productServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetOrderByIdReturnsSingleEntryAndSuccess()
        {
            var result = Task.FromResult(new DTO.OrderDTO { Id = 1, AccountName = "Test Method" });
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(1);

            var proxyOrder = orderServiceResponse.target;

            Assert.AreEqual(1, proxyOrder.Id);
            Assert.IsTrue(orderServiceResponse.successful);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetOrderByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.OrderDTO>(null);
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Returns(result);

            DodgyDealersServiceResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(999);

            Assert.IsFalse(orderServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, orderServiceResponse.message);
        }

        [TestMethod]
        public async Task DodgyDealersExternalServiceProxyGetOrderByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            DodgyDealersServiceResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(1);

            Assert.IsFalse(orderServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, orderServiceResponse.message);
        }
    }
}