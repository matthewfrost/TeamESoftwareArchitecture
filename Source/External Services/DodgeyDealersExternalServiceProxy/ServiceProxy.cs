using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DodgeyDealersExternalServiceProxy.Responses;

namespace DodgeyDealersExternalServiceProxy
{
    public class ServiceProxy
    {
        private HttpClient client;

        public ServiceProxy()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://dodgydealers.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>>> GetAllBrands()
        {
            HttpResponseMessage response = await client.GetAsync("api/Brand");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>>();
                    IEnumerable<DTO.BrandDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.BrandDTO>>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get all Brands";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> { successful = false, target = null, message = ex.Message };
                }

            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<DTO.BrandDTO>> GetBrandById(int id)
        {
            string requestUri = string.Format("api/Brand/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<DTO.BrandDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.BrandDTO>();
                    DTO.BrandDTO returnedData = await response.Content.ReadAsAsync<DTO.BrandDTO>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get Brand by Id";
                    }

                    return serviceProxyResponse;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<DTO.BrandDTO> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<DTO.BrandDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>>> GetAllCategories()
        {
            HttpResponseMessage response = await client.GetAsync("api/Category");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>>();
                    IEnumerable<DTO.CategoryDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.CategoryDTO>>();

                    if (returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get all Categories";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> { successful = false, target = null, message = ex.Message };
                }

            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<DTO.CategoryDTO>> GetCategoryById(int id)
        {
            string requestUri = string.Format("api/Category/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<DTO.CategoryDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.CategoryDTO>();
                    DTO.CategoryDTO returnedData = await response.Content.ReadAsAsync<DTO.CategoryDTO>();

                    if (returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get Category by Id";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<DTO.CategoryDTO> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<DTO.CategoryDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>> GetAllProducts()
        {
            HttpResponseMessage response = await client.GetAsync("api/Product");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>();
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get all Products";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = ex.Message };
                }

            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<DTO.ProductDTO>> GetProductById(int id)
        {
            string requestUri = string.Format("api/Product/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<DTO.ProductDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.ProductDTO>();
                    DTO.ProductDTO returnedData = await response.Content.ReadAsAsync<DTO.ProductDTO>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get Product by Id";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<DTO.ProductDTO> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<DTO.ProductDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }
        
        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>> GetProduct(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            string requestUri = string.Format("api/Product?category_id={0}&category_name={1}&brand_id={2}&min_price={3}&max_price={4}", category_id, category_name, brand_id, min_price, max_price);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>();
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get filtered Product";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        public async Task<DodgyDealersServiceResponse<DTO.OrderDTO>> GetOrder(int id)
        {
            string requestUri = string.Format("api/Order/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DodgyDealersServiceResponse<DTO.OrderDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.OrderDTO>();
                    DTO.OrderDTO returnedData = await response.Content.ReadAsAsync<DTO.OrderDTO>();

                    if(returnedData != null)
                    {
                        serviceProxyResponse.successful = true;
                        serviceProxyResponse.target = returnedData;
                    }
                    else
                    {
                        serviceProxyResponse.successful = false;
                        serviceProxyResponse.message = "No data returned from DodgyDealers for Get an Order by Id";
                    }

                    return serviceProxyResponse; 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new DodgyDealersServiceResponse<DTO.OrderDTO> { successful = false, target = null, message = ex.Message };
                }
            }
            else
            {
                Debug.WriteLine("Bad request");
                return new DodgyDealersServiceResponse<DTO.OrderDTO> { successful = false, target = null, message = response.ReasonPhrase };
            }
        }

        //public DTO.OrderDTO PostOrder()
        //{
        //    DTO.OrderDTO order = new DTO.OrderDTO
        //    {
        //        Id = 1,
        //        AccountName = "Test Account Name",
        //        CardNumber = "Test Card Number",
        //        ProductId = 1,
        //        Quantity = 1,
        //        When = DateTime.Now,
        //        ProductName = "Test Product Name",
        //        ProductEan = "Test Product Ean",
        //        TotalPrice = 1.23m
        //    };

        //    HttpResponseMessage response = client.PostAsJsonAsync("api/Order", order).Result;

        //    return response;
        //}


    }
}
