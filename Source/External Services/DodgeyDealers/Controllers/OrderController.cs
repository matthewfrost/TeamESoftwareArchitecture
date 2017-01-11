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
    public class OrderController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy();

        //GET: api/Order/id
        public async Task<DodgeyDealersExternalServiceProxy.DTO.OrderDTO> Get(int id)
        {
            DodgyDealersServiceResponse<DodgeyDealersExternalServiceProxy.DTO.OrderDTO> order = await proxy.GetOrder(id);

            if (order.successful)
            {
                return order.target;
            }
            else
            {
                return null;
            }
            
        }

        
        [HttpPost]
        public void Post()
        {
        }

        // DELETE: api/Default/5
        [HttpDelete]
        public void MyDelete(int id)
        {
        }

        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
