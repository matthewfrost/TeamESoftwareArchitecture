using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServiceProxy
{
    public class ServiceInteraction
    {
        private HttpClient client;

        public ServiceInteraction()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public virtual async Task<IEnumerable<DTO.BrandDTO>> GetAllBrandsFromServer()
        {
            HttpResponseMessage response = await client.GetAsync("api/Brand");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.BrandDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.BrandDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<DTO.BrandDTO> GetBrandByIdFromServer(int id)
        {
            string requestUri = string.Format("api/Brand/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DTO.BrandDTO returnedData = await response.Content.ReadAsAsync<DTO.BrandDTO>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<IEnumerable<DTO.CategoryDTO>> GetAllCategoriesFromServer()
        {
            HttpResponseMessage response = await client.GetAsync("api/Category");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.CategoryDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.CategoryDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<DTO.CategoryDTO> GetCategoryByIdFromServer(int id)
        {
            string requestUri = string.Format("api/Category/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DTO.CategoryDTO returnedData = await response.Content.ReadAsAsync<DTO.CategoryDTO>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<IEnumerable<DTO.ProductDTO>> GetAllProductsFromServer()
        {
            HttpResponseMessage response = await client.GetAsync("api/Product");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    IEnumerable<DTO.ProductDTO> returnedData = await response.Content.ReadAsAsync<IEnumerable<DTO.ProductDTO>>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<DTO.ProductDTO> GetProductByIdFromServer(int id)
        {
            string requestUri = string.Format("api/Product/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DTO.ProductDTO returnedData = await response.Content.ReadAsAsync<DTO.ProductDTO>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<IEnumerable<DTO.ProductDTO>> GetProductFromServer(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            string requestUri = string.Format("api/Product?category_id={0}&category_name={1}&brand_id={2}&min_price={3}&max_price={4}", category_id, category_name, brand_id, min_price, max_price);

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
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public virtual async Task<DTO.OrderDTO> GetOrderByIdFromServer(int id)
        {
            string requestUri = string.Format("api/Order/{0}", id);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    DTO.OrderDTO returnedData = await response.Content.ReadAsAsync<DTO.OrderDTO>();
                    return returnedData;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }
            else
                return null;
        }
    }
}
