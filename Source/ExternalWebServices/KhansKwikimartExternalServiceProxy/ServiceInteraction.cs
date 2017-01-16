using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhansKwikimartExternalServiceProxy
{
    public class ServiceInteraction
    {
        private HttpClient client;

        public ServiceInteraction()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://khanskwikimart.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public virtual async Task<IEnumerable<DTO.RangeDTO>> GetGiftWrappingByRangeFromServer()
        {
            HttpResponseMessage response = await client.GetAsync("api/giftwrapping/ranges");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.RangeDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.RangeDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<IEnumerable<DTO.TypeDTO>> GetGiftWrappingByTypeFromServer()
        {
            HttpResponseMessage response = await client.GetAsync("api/giftwrapping/types");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.TypeDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.TypeDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<IEnumerable<DTO.ProductDTO>> GetGiftWrappingFromServer(int type_id, int range_id, decimal min_price, decimal max_price, decimal min_size, decimal max_size)
        {
            string requestUri = string.Format("api/giftwrapping/products?type_id={0}&range_id={1}&min_price={2}&max_price={3}&min_size={4}&max_size={5}", type_id, range_id, min_price, max_price, min_size, max_size);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
            else
                return null;
        }
    }
}
