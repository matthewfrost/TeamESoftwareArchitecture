using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using ExternalServiceProxy;
using ExternalServiceProxy.Responses;

namespace ICA6.Controllers
{
    public class CategoryController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy(new ServiceInteraction());

        // GET: api/Category
        public async Task<IEnumerable<ExternalServiceProxy.DTO.CategoryDTO>> Get()
        {
           UndercuttersResponse<IEnumerable<ExternalServiceProxy.DTO.CategoryDTO>> category = await proxy.GetAllCategories();

            if (category.successful)
            {
                return category.target;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Category/5
        public async Task<ExternalServiceProxy.DTO.CategoryDTO> Get(int id)
        {
            UndercuttersResponse<ExternalServiceProxy.DTO.CategoryDTO> category = await proxy.GetCategoryById(id);

            if (category.successful)
            {
                return category.target;
            }
            else
            {
                return null;
            }
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
