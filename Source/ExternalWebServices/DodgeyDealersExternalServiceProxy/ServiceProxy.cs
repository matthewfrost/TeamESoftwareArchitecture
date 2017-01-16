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
        private ServiceInteraction ServiceInteraction;

        public ServiceProxy(ServiceInteraction serviceInteraction)
        {
            if (serviceInteraction == null)
                throw new MissingMemberException();

            ServiceInteraction = serviceInteraction;
        }

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>>> GetAllBrands()
        {
            try
            {
                DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.BrandDTO>>();
                IEnumerable<DTO.BrandDTO> returnedData = await ServiceInteraction.GetAllBrandsFromServer();

                if (returnedData.Count() != 0)
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

        public async Task<DodgyDealersServiceResponse<DTO.BrandDTO>> GetBrandById(int id)
        {
            try
            {
                DodgyDealersServiceResponse<DTO.BrandDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.BrandDTO>();
                DTO.BrandDTO returnedData = await ServiceInteraction.GetBrandByIdFromServer(id);

                if (returnedData != null)
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

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>>> GetAllCategories()
        {
            try
            {
                DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.CategoryDTO>>();
                IEnumerable<DTO.CategoryDTO> returnedData = await ServiceInteraction.GetAllCategoriesFromServer();

                if (returnedData.Count() != 0)
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

        public async Task<DodgyDealersServiceResponse<DTO.CategoryDTO>> GetCategoryById(int id)
        {
            try
            {
                DodgyDealersServiceResponse<DTO.CategoryDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.CategoryDTO>();
                DTO.CategoryDTO returnedData = await ServiceInteraction.GetCategoryByIdFromServer(id);

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

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>> GetAllProducts()
        {
            try
            {
                DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>();
                IEnumerable<DTO.ProductDTO> returnedData = await ServiceInteraction.GetAllProductsFromServer();

                if (returnedData.Count() != 0)
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

        public async Task<DodgyDealersServiceResponse<DTO.ProductDTO>> GetProductById(int id)
        {
            try
            {
                DodgyDealersServiceResponse<DTO.ProductDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.ProductDTO>();
                DTO.ProductDTO returnedData = await ServiceInteraction.GetProductByIdFromServer(id);

                if (returnedData != null)
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

        public async Task<DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>> GetProduct(int category_id, string category_name, int brand_id, double min_price, double max_price)
        {
            try
            {
                DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>> serviceProxyResponse = new DodgyDealersServiceResponse<IEnumerable<DTO.ProductDTO>>();
                IEnumerable<DTO.ProductDTO> returnedData = await ServiceInteraction.GetProductFromServer(category_id, category_name, brand_id, min_price, max_price);

                if (returnedData.Count() != 0)
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

        public async Task<DodgyDealersServiceResponse<DTO.OrderDTO>> GetOrderById(int id)
        {
            try
            {
                DodgyDealersServiceResponse<DTO.OrderDTO> serviceProxyResponse = new DodgyDealersServiceResponse<DTO.OrderDTO>();
                DTO.OrderDTO returnedData = await ServiceInteraction.GetOrderByIdFromServer(id);

                if (returnedData != null)
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
