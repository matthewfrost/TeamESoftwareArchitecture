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
    public class BrandController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy();

        // GET: api/Brand
        public async Task<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.BrandDTO>> Get()
        {
            DodgyDealersServiceResponse<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.BrandDTO>> brands = await proxy.GetAllBrands();

            if (brands.successful)
            {
                return brands.target;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Brand/5
        public async Task<DodgeyDealersExternalServiceProxy.DTO.BrandDTO> Get(int id)
        {
            DodgyDealersServiceResponse<DodgeyDealersExternalServiceProxy.DTO.BrandDTO> brand = await proxy.GetBrandById(id);

            if (brand.successful)
            {
                return brand.target;
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
