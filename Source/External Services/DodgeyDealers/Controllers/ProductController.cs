using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using DodgeyDealersExternalServiceProxy.Responses;

using DodgeyDealersExternalServiceProxy;

namespace DodgeyDealers.Controllers
{
    public class ProductController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy();

        // GET: api/Product
        // TESTING PURPOSES
        public async Task<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.ProductDTO>> Get()
        {
            DodgyDealersServiceResponse<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.ProductDTO>> product = await proxy.GetAllProducts();

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
        public async Task<DodgeyDealersExternalServiceProxy.DTO.ProductDTO> Get(int id)
        {
            DodgyDealersServiceResponse<DodgeyDealersExternalServiceProxy.DTO.ProductDTO> product = await proxy.GetProductById(id);

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
        //[Route("api/Product?category_id={category_id}&category_name={category_name}&brand_id={brand_id}&min_price={min_price}&max_price={max_price}")]
        [HttpGet]
        public async Task<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.ProductDTO>> Get(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            DodgyDealersServiceResponse<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.ProductDTO>> product = await proxy.GetProduct(category_id, category_name, brand_id, min_price, max_price);

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
