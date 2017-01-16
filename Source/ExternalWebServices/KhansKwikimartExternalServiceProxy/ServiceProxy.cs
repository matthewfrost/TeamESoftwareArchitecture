using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KhansKwikimartExternalServiceProxy.Responses;

namespace KhansKwikimartExternalServiceProxy
{
    public class ServiceProxy
    {
        private ServiceInteraction ServiceInteraction;

        public ServiceProxy(ServiceInteraction serviceInteraction)
        {
            if (serviceInteraction == null)
                throw new MissingMemberException();

            ServiceInteraction = serviceInteraction;
        }

        public async Task<KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>>> GetGiftWrappingByRange()
        {
            try
            {
                KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.RangeDTO>>();
                IEnumerable<DTO.RangeDTO> returnedData = await ServiceInteraction.GetGiftWrappingByRangeFromServer();

                if (returnedData.Count() != 0)
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

        public async Task<KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>>> GetGiftWrappingByType()
        {

            try
            {
                KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.TypeDTO>>();
                IEnumerable<DTO.TypeDTO> returnedData = await ServiceInteraction.GetGiftWrappingByTypeFromServer();

                if (returnedData.Count() != 0)
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

        //api/giftwrapping/products?type_id=1&range_id=1&min_price=0&max_price=100&min_size=0&max_size=100
        public async Task<KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>>> GetGiftWrapping(int type_id, int range_id, decimal min_price, decimal max_price, decimal min_size, decimal max_size)
        {

            try
            {
                KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new KhansKwikimartResponse<IEnumerable<DTO.ProductDTO>>();
                IEnumerable<DTO.ProductDTO> returnedData = await ServiceInteraction.GetGiftWrappingFromServer(type_id, range_id, min_price, max_price, min_size, max_size);

                if (returnedData.Count() != 0)
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
    }
}
