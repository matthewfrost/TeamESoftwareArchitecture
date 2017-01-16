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
    public class BrandController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy(new ServiceInteraction());

        // GET: api/Brand
        public async Task<IEnumerable<ExternalServiceProxy.DTO.BrandDTO>> Get()
        {
            UndercuttersResponse<IEnumerable<ExternalServiceProxy.DTO.BrandDTO>> brandsServiceResponse = await proxy.GetAllBrands();

            if (brandsServiceResponse.successful)
            {
                return brandsServiceResponse.target;
            }
                
            else
            {
                //Do whatever you want with the message here
                return null;
            }

        }

        // GET: api/Brand/5
        public async Task<ExternalServiceProxy.DTO.BrandDTO> Get(int id)
        {
            UndercuttersResponse<ExternalServiceProxy.DTO.BrandDTO> brandsServiceResponse = await proxy.GetBrandById(id);

            if (brandsServiceResponse.successful)
            {
                return brandsServiceResponse.target;
            }
            else
            {
                return null;
            }
            
        }

        // POST: api/Brand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
