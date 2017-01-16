using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BazzasBazaarExternalServiceProxyWCF;
using System.Web.Http;
using System.Threading.Tasks;

namespace BazzaBazzars.Controllers
{
    public class BazzaController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy();

        // GET: api/GetAllCategories
        [Route("api/GetAllCategories")]
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Category[]> GetAllCategories()
        {
            var categories = await proxy.getAllCategories();
            return categories;
        }

        // GET: api/GetCategoryById
        [Route("api/GetCategoryById/{id}")]
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Category> GetCategoryById(int id)
        {
            var category = await proxy.getCategoryById(id);
            return category;
        }

        // GET: api/GetProductById
        [Route("api/GetProductById/{id}")]
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Product> GetProductById(int id)
        {
            var product = await proxy.getProductById(id);
            return product;
        }

        // GET: api/GetOrderById
        [Route("api/GetOrderById/{id}")]
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Order> GetOrderById(int id)
        {
            var order = await proxy.getOrderById(id);
            return order;
        }

        // GET: api/GetFilteredProducts
        [Route("api/GetFilteredProducts/{categoryId}/{categoryName}/{minPrice}/{maxPrice}")]
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Product[]> GetFilteredProducts(int categoryId, string categoryName, double minPrice, double maxPrice)
        {
            var products = await proxy.getFilteredProducts(categoryId,categoryName,minPrice,maxPrice);
            return products;
        }

        // GET: api/Bazza/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bazza
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bazza/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bazza/5
        public void Delete(int id)
        {
        }
    }
}
