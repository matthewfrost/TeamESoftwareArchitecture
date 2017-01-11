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
        private HttpClient client;

        public ServiceProxy()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.BrandDTO>>> GetAllBrands()
        {
            HttpResponseMessage response = await client.GetAsync("api/Brand");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<IEnumerable<DTO.BrandDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.BrandDTO>>();

                    IEnumerable<DTO.BrandDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.BrandDTO>>();

                    if (returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<IEnumerable<DTO.BrandDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<DTO.BrandDTO>> GetBrandById(int id)
        {
            string requestUri = string.Format("api/Brand/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<DTO.BrandDTO> serviceProxyResponse = new UndercuttersResponse<DTO.BrandDTO>();

                    DTO.BrandDTO returnedData = await response.Content.ReadAsAsync<DTO.BrandDTO>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<DTO.BrandDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.CategoryDTO>>> GetAllCategories()
        {
            HttpResponseMessage response = await client.GetAsync("api/Category");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.CategoryDTO>>();

                    IEnumerable<DTO.CategoryDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.CategoryDTO>>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<IEnumerable<DTO.CategoryDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<DTO.CategoryDTO>> GetCategoryById(int id)
        {
            string requestUri = string.Format("api/Category/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<DTO.CategoryDTO> serviceProxyResponce = new UndercuttersResponse<DTO.CategoryDTO>();

                    DTO.CategoryDTO returnedData = await response.Content.ReadAsAsync<DTO.CategoryDTO>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<DTO.CategoryDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.ProductDTO>>> GetAllProducts()
        {
            HttpResponseMessage response = await client.GetAsync("api/Product");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.ProductDTO>>();

                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<DTO.ProductDTO>> GetProductById(int id)
        {
            string requestUri = string.Format("api/Product/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<DTO.ProductDTO> serviceProxyResponse = new UndercuttersResponse<DTO.ProductDTO>();

                    DTO.ProductDTO returnedData = await response.Content.ReadAsAsync<DTO.ProductDTO>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<DTO.ProductDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<IEnumerable<DTO.ProductDTO>>> GetProduct(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            string requestUri = string.Format("api/Product?category_id={0}&category_name={1}&brand_id={2}&min_price={3}&max_price={4}", category_id, category_name, brand_id, min_price, max_price);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new UndercuttersResponse<IEnumerable<DTO.ProductDTO>>();
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<UndercuttersResponse<DTO.OrderDTO>> GetOrder(int id)
        {
            string requestUri = string.Format("api/Order/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    UndercuttersResponse<DTO.OrderDTO> serviceProxyResponse = new UndercuttersResponse<DTO.OrderDTO>();

                    DTO.OrderDTO returnedData = await response.Content.ReadAsAsync<DTO.OrderDTO>();

                    if(returnedData != null)
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
            else
            {
                Debug.WriteLine("Bad request");
                return new UndercuttersResponse<DTO.OrderDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }


        public async Task<DTO.PostOrderDTO> PostOrder(DTO.PostOrderDTO order)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Order", order);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return await response.Content.ReadAsAsync<DTO.PostOrderDTO>();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return null;
            }
            
        }

        //public async Task<DTO.OrderDTO> Delete(DTO.OrderDTO)
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
