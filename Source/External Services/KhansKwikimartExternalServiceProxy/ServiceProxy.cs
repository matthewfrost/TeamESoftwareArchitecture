using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KhansKwikimartExternalServiceProxy.Responses;

namespace KhansKwikimartExternalServiceProxy
{
    public class ServiceProxy
    {
        private HttpClient client;

        public ServiceProxy()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://khanskwikimart.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>>> GetGiftWrappingByRange()
        {
            HttpResponseMessage response = await client.GetAsync("api/giftwrapping/ranges");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>>();
                    IEnumerable<DTO.RangeDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.RangeDTO>>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from Khans Kwikimart for Get Giftwrapping by Range";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> { successful = false, target = null, message = ex.Message };
                }

            }
            else
            {
                Debug.WriteLine("Bad request");
                return new KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>>> GetGiftWrappingByType()
        {
            HttpResponseMessage response = await client.GetAsync("api/giftwrapping/types");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>>();
                    IEnumerable<DTO.TypeDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.TypeDTO>>();

                    if (returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from Khans Kwikimart for Get Giftwrapping by Type";
                    }

                    return serviceProxyResponse;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> { successful = false, target = null, message = ex.Message };
                }

            }
            else
            {
                Debug.WriteLine("Bad request");
                return new KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        //api/giftwrapping/products?type_id=1&range_id=1&min_price=0&max_price=100&min_size=0&max_size=100
        public async Task<KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>>> GetGiftWrapping(int type_id, int range_id, decimal min_price, decimal max_price, decimal min_size, decimal max_size)
        {
            string requestUri = string.Format("api/giftwrapping/products?type_id={0}&range_id={1}&min_price={2}&max_price={3}&min_size={4}&max_size={5}", type_id, range_id, min_price, max_price, min_size, max_size);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>>();
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from Khans Kwikimart for Get Giftwrappiung through filters";
                    }
                    return serviceProxyResponse;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }
    }
}
