using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExternalServiceProxy;
using ExternalServiceProxy.Responses;
using System.Threading.Tasks;


namespace ICA6.Controllers
{
    public class ProductController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy();

        // GET: api/Product
        // TESTING PURPOSES
        public async Task<IEnumerable<ExternalServiceProxy.DTO.ProductDTO>> Get()
        {
            UndercuttersResponse<IEnumerable<ExternalServiceProxy.DTO.ProductDTO>> product = await proxy.GetAllProducts();

            if (product.successful)
            {
                return product.target;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Product/5
        public async Task<ExternalServiceProxy.DTO.ProductDTO> Get(int id)
        {
            UndercuttersResponse<ExternalServiceProxy.DTO.ProductDTO> product = await proxy.GetProductById(id);

            if (product.successful)
            {
                return product.target;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Product?category_id={category_id}&category_name={category_name}&brand_id={brand_id}&min_price={min_price}&max_price={max_price}
        // Test works: /api/Product?category_id=2&category_name=Covers&brand_id=3&min_price=1&max_price=50
        [HttpGet]
        public async Task<IEnumerable<ExternalServiceProxy.DTO.ProductDTO>> Get(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            UndercuttersResponse<IEnumerable<ExternalServiceProxy.DTO.ProductDTO>> product = await proxy.GetProduct(category_id, category_name, brand_id, min_price, max_price);

            if (product.successful)
            {
                return product.target;
            }
            else
            {
                return null;
            }
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
