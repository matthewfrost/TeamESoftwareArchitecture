using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace usersWebService.Controllers
{
    public class ProductController : ApiController
    {
        ProductRepository productrepository;
        // GET: api/Product
        public ProductController()
        {
            this.productrepository = new ProductRepository(new ProductdbEntities());
        }
        public List<DTOs.Product> Get()
        {
            return productrepository.GetAll();
        }

        // GET: api/Product/5
        public DTOs.Product GetByID(int id)
        {
            return productrepository.GetById(id);
        }

        // POST: api/Product
        public void Post([FromBody]DTOs.Product product)
        {
            productrepository.CreateProduct(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]DTOs.Product product)
        {
            productrepository.UpdateProduct(product, id);
        }

        public DTOs.Product GetItemsForBox(int boxid)
        {
            return productrepository.getItemsForBox(boxid);
        }
    }
}
