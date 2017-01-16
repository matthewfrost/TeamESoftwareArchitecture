using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using KhansKwikimartExternalServiceProxy.Responses;

using KhansKwikimartExternalServiceProxy;

namespace KhansKwikiMart.Controllers
{
    public class GiftWrappingController : ApiController
    {
        ServiceProxy proxy = new ServiceProxy(new ServiceInteraction());

        // GET: api/giftwrapping/ranges
        [Route("api/giftwrapping/ranges")]
        public async Task<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.RangeDTO>> GetByRanges()
        {
            KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.RangeDTO>> giftWrapping = await proxy.GetGiftWrappingByRange();

            if (giftWrapping.successful)
            {
                return giftWrapping.target;
            }
            else
            {
                return null;
            }
        }

        // GET: api/giftwrapping/types
        [Route("api/giftwrapping/types")]
        public async Task<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.TypeDTO>> GetByTypes()
        {
            KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.TypeDTO>> giftWrapping = await proxy.GetGiftWrappingByType();

            if (giftWrapping.successful)
            {
                return giftWrapping.target;
            }
            else
            {
                return null;
            }
        }

        //GET: Test works: api/GiftWrapping?type_id=1&range_id=1&min_price=0&max_price=100&min_size=0&max_size=100
        public async Task<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.ProductDTO>> Get(int type_id, int range_id, decimal min_price, decimal max_price, decimal min_size, decimal max_size)
        {
            KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.ProductDTO>> product = await proxy.GetGiftWrapping(type_id, range_id, min_price, max_price, min_size, max_size);

            if (product.successful)
            {
                return product.target;
            }
            else
            {
                return null;
            }
        }

        // POST: api/GiftWrapping
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GiftWrapping/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GiftWrapping/5
        public void Delete(int id)
        {
        }
    }
}
