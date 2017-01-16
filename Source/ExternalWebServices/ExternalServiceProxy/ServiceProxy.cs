using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExternalServiceProxy.Responses;

namespace ExternalServiceProxy
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

        public async Task<UndercuttersResponse<IEnumerable<DTO.BrandDTO>>> GetAllBrands()
        {
            try
            {
                UndercuttersResponse<IEnumerable<DTO.BrandDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.BrandDTO>>();

                //IEnumerable<DTO.BrandDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.BrandDTO>>();
                IEnumerable<DTO.BrandDTO> returnedData = await ServiceInteraction.GetAllBrandsFromServer();

                if (returnedData.Count() != 0)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutters for Get all Brands";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<IEnumerable<DTO.BrandDTO>> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<DTO.BrandDTO>> GetBrandById(int id)
        {
            try
            {
                UndercuttersResponse<DTO.BrandDTO> serviceProxyResponse = new UndercuttersResponse<DTO.BrandDTO>();

                DTO.BrandDTO returnedData = await ServiceInteraction.GetBrandByIdFromServer(id);

                if (returnedData != null)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No Data returned from Undercutters for Brand by Id";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<DTO.BrandDTO> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.CategoryDTO>>> GetAllCategories()
        {
            try
            {
                UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.CategoryDTO>>();

                IEnumerable<DTO.CategoryDTO> returnedData = await ServiceInteraction.GetAllCategoriesFromServer();

                if (returnedData.Count() != 0)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutters for Get all Categories";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<DTO.CategoryDTO>> GetCategoryById(int id)
        {
            try
            {
                UndercuttersResponse<DTO.CategoryDTO> serviceProxyResponce = new UndercuttersResponse<DTO.CategoryDTO>();

                DTO.CategoryDTO returnedData = await ServiceInteraction.GetCategoryByIdFromServer(id);

                if (returnedData != null)
                {
                    serviceProxyResponce.successful = true;
                    serviceProxyResponce.target = returnedData;
                }
                else
                {
                    serviceProxyResponce.successful = false;
                    serviceProxyResponce.message = "No data returned from Undercutters for Get Catergory by Id";
                }

                return serviceProxyResponce;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<DTO.CategoryDTO> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.ProductDTO>>> GetAllProducts()
        {
            try
            {
                UndercuttersResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.ProductDTO>>();

                IEnumerable<DTO.ProductDTO> returnedData = await ServiceInteraction.GetAllProductsFromServer();

                if (returnedData.Count() != 0)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutters for Get all Products";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<DTO.ProductDTO>> GetProductById(int id)
        {
            try
            {
                UndercuttersResponse<DTO.ProductDTO> serviceProxyResponse = new UndercuttersResponse<DTO.ProductDTO>();

                DTO.ProductDTO returnedData = await ServiceInteraction.GetProductByIdFromServer(id);

                if (returnedData != null)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutter for Get Product by Id";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<DTO.ProductDTO> { successful = false, target = null, message = ex.Message };
            }


        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.ProductDTO>>> GetProduct(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            try
            {
                UndercuttersResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.ProductDTO>>();
                IEnumerable<DTO.ProductDTO> returnedData = await ServiceInteraction.GetProductFromServer(category_id, category_name, brand_id, min_price, max_price);

                if (returnedData.Count() != 0)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutters for Get a filtered Product";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = ex.Message };
            }
        }

        public async Task<UndercuttersResponse<DTO.OrderDTO>> GetOrderById(int id)
        {
            try
            {
                UndercuttersResponse<DTO.OrderDTO> serviceProxyResponse = new UndercuttersResponse<DTO.OrderDTO>();

                DTO.OrderDTO returnedData = await ServiceInteraction.GetOrderByIdFromServer(id);

                if (returnedData != null)
                {
                    serviceProxyResponse.successful = true;
                    serviceProxyResponse.target = returnedData;
                }
                else
                {
                    serviceProxyResponse.successful = false;
                    serviceProxyResponse.message = "No data returned from Undercutters for Getting an Order by Id";
                }

                return serviceProxyResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new UndercuttersResponse<DTO.OrderDTO> { successful = false, target = null, message = ex.Message };
            }

        }

        //public async Task<DTO.PostOrderDTO> PostOrder(DTO.PostOrderDTO order)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/Order", order);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        try
        //        {
        //            return await response.Content.ReadAsAsync<DTO.PostOrderDTO>();
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Bad request");
        //        return null;
        //    }

        //}

    }
}
