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

        // GET: api/Bazza
        public async Task<BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Category[]> GetAllCategories()
        {
            var category = await proxy.getAllCategories();
            return category;
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
