using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExternalServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExternalServiceProxy.Responses;
using FakeItEasy;
using System.Net.Http.Formatting;

namespace ExternalServiceProxy.Tests
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
        public void UndercuttersExternalServiceProxyConstructorSuccessfullyCreatesObject()
        {
            proxy = new ServiceProxy(serviceInteraction);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void UndercuttersExternalServiceProxyConstructorThrowsExceptionWithMissingServiceInteraction()
        {
            proxy = new ServiceProxy(null);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllBrandsReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.BrandDTO>>(new List<DTO.BrandDTO> { new DTO.BrandDTO { Id = 1, Name = "Test Brand", AvailableProductCount = 2 } });
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            var proxyBrand = brandsServiceResponse.target;

            Assert.AreNotEqual(0, proxyBrand.Count());
            Assert.IsTrue(brandsServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllBrandsReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.BrandDTO>>(new List<DTO.BrandDTO>());
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            var proxyBrand = brandsServiceResponse.target;

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllBrandsReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllBrandsFromServer()).Throws(new Exception());

            UndercuttersResponse<IEnumerable<DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetBrandByIdReturnsSingleEntryAndTrueWithValidId()
        {
            var result = Task.FromResult(new DTO.BrandDTO { Id = 1, Name = "Test Brand", AvailableProductCount = 2 });
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(1);

            var proxyBrand = brandsServiceResponse.target;

            Assert.AreEqual(1, proxyBrand.Id);
            Assert.IsTrue(brandsServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetBrandByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.BrandDTO>(null);
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(999);

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetBrandByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetBrandByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            UndercuttersResponse<DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(1);

            Assert.IsFalse(brandsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, brandsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllCategoriesReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.CategoryDTO>>(new List<DTO.CategoryDTO> { new DTO.CategoryDTO { Id = 1, Name = "Test Category", AvailableProductCount = 2, Description = "Test Description" } });

            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            var proxyCategories = categoriesServiceResponse.target;

            Assert.AreNotEqual(0, proxyCategories.Count());
            Assert.IsTrue(categoriesServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllCategoriesReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.CategoryDTO>>(new List<DTO.CategoryDTO>());

            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            Assert.IsFalse(categoriesServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoriesServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllCategoriesReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllCategoriesFromServer()).Throws(new Exception());

            UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> categoriesServiceResponse = await proxy.GetAllCategories();

            Assert.IsFalse(categoriesServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, categoriesServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetCategoryByIdReturnsSingleEntryAndTrueWithValidId()
        {
            var result = Task.FromResult(new DTO.CategoryDTO { Id = 1, Name = "Test Brand", AvailableProductCount = 2, Description = "Test Description" });
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(1);

            var proxyCategory = categoryServiceResponse.target;

            Assert.AreEqual(1, proxyCategory.Id);
            Assert.IsTrue(categoryServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetCategoryByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.CategoryDTO>(null);
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(999);

            Assert.AreNotEqual(string.Empty, categoryServiceResponse.message);
            Assert.IsFalse(categoryServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetCategoryByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetCategoryByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            UndercuttersResponse<DTO.CategoryDTO> categoryServiceResponse = await proxy.GetCategoryById(1);

            Assert.AreNotEqual(string.Empty, categoryServiceResponse.message);
            Assert.IsFalse(categoryServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllProductsReturnsPopulatedListAndSuccess()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO> { new DTO.ProductDTO { Id = 1, Name = "Test Product" } });
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            var proxyProducts = productsServiceResponse.target;

            Assert.AreNotEqual(0, proxyProducts.Count());
            Assert.IsTrue(productsServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllProductsReturnsFalseAndMessageWhenListIsEmpty()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetAllProductsReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetAllProductsFromServer()).Throws(new Exception());

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetAllProducts();

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductByIdReturnsSingleEntryAndSuccessWithValidId()
        {
            var result = Task.FromResult(new DTO.ProductDTO { Id = 1, Name = "Test Product" });
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.ProductDTO> productsServiceResponse = await proxy.GetProductById(1);

            var proxyProduct = productsServiceResponse.target;

            Assert.AreEqual(1, proxyProduct.Id);
            Assert.IsTrue(productsServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductByIdReturnsFalseAndMessageWithInvalidId()
        {
            var result = Task.FromResult<DTO.ProductDTO>(null);
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.ProductDTO> productsServiceResponse = await proxy.GetProductById(1);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetProductByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            UndercuttersResponse<DTO.ProductDTO> productsServiceResponse = await proxy.GetProductById(1);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsPopulatedListAndSuccessWithValidParameters()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO> { new DTO.ProductDTO { Id = 1, Name = "Test Product" } });
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1,"Test",1,0,100);

            var proxyProducts = productsServiceResponse.target;

            Assert.AreNotEqual(0, proxyProducts.Count());
            Assert.IsTrue(productsServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidCategoryId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(999, "Screen Protectors", 1, 0, 100);
            
            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidCategoryName()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1, "Test", 1, 0, 100);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidBrandId()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 999, 0, 100);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidMinPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 100, 100);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWithInvalidMaxPrice()
        {
            var result = Task.FromResult<IEnumerable<DTO.ProductDTO>>(new List<DTO.ProductDTO>());
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Returns(result);

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 0, 0);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetProductReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetProductFromServer(A<int>.Ignored, A<string>.Ignored, A<int>.Ignored, A<double>.Ignored, A<double>.Ignored)).Throws(new Exception());

            UndercuttersResponse<IEnumerable<DTO.ProductDTO>> productsServiceResponse = await proxy.GetProduct(1, "Screen Protectors", 1, 0, 100);

            Assert.IsFalse(productsServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, productsServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetOrderByIdReturnsSingleEntryAndSuccessWithValidId()
        {
            var result = Task.FromResult(new DTO.OrderDTO { Id = 1, ProductName = "Test Order" });
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(1);

            var proxyOrder = orderServiceResponse.target;

            Assert.AreEqual(1, proxyOrder.Id);
            Assert.IsTrue(orderServiceResponse.successful);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetOrderByIdReturnsFalseAndMessageWhenDataIsNull()
        {
            var result = Task.FromResult<DTO.OrderDTO>(null);
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Returns(result);

            UndercuttersResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(999);
            
            Assert.IsFalse(orderServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, orderServiceResponse.message);
        }

        [TestMethod]
        public async Task UndercuttersExternalServiceProxyGetOrderByIdReturnsFalseAndMessageWhenExceptionIsThrown()
        {
            A.CallTo(() => serviceInteraction.GetOrderByIdFromServer(A<int>.Ignored)).Throws(new Exception());

            UndercuttersResponse<DTO.OrderDTO> orderServiceResponse = await proxy.GetOrderById(1);

            Assert.IsFalse(orderServiceResponse.successful);
            Assert.AreNotEqual(string.Empty, orderServiceResponse.message);
        }
    }
}