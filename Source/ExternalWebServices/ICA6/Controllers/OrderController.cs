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
    public class OrderController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy(new ServiceInteraction());

        [HttpGet]
        public async Task<ExternalServiceProxy.DTO.OrderDTO> Get(int id)
        {
            UndercuttersResponse<ExternalServiceProxy.DTO.OrderDTO> order = await proxy.GetOrderById(id);

            if (order.successful)
            {
                return order.target;
            }
            else
            {
                return null;
            }
        }

        //[HttpPost]
        //public async Task<ExternalServiceProxy.DTO.PostOrderDTO> Post()
        //{
        //    ExternalServiceProxy.DTO.PostOrderDTO order = new ExternalServiceProxy.DTO.PostOrderDTO
        //    {
        //        AccountName = "Test Account Name",
        //        CardNumber = "Test Card Number",
        //        ProductId = 1,
        //        Quantity = 1
        //    };

        //    ExternalServiceProxy.DTO.PostOrderDTO orderResponse = await proxy.PostOrder(order);

        //    if (orderResponse == null)
        //    {

        //    }

        //    return orderResponse;
        //}
        
        // DELETE: api/Default/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
