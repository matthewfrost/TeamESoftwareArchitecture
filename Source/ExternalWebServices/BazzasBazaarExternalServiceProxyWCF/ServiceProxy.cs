using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazzasBazaarExternalServiceProxyWCF
{
    public class ServiceProxy
    {
        BazzasBazaarService.StoreClient WCFClient = new BazzasBazaarService.StoreClient();
        
        public async Task<BazzasBazaarService.Category[]> getAllCategories()
        {
            var categories = await WCFClient.GetAllCategoriesAsync();
            return categories;
        }

        public async Task<BazzasBazaarService.Category> getCategoryById(int id)
        {
            var category = await WCFClient.GetCategoryByIdAsync(id);
            return category;
        }
        
        public async Task<BazzasBazaarService.Product[]> getFilteredProducts(int categoryId, string categoryName, double minPrice, double maxPrice)
        {
            var products = await WCFClient.GetFilteredProductsAsync(categoryId, categoryName, minPrice, maxPrice);
            return products;
        }

        public async Task<BazzasBazaarService.Product> getProductById(int id)
        {
            var product = await WCFClient.GetProductByIdAsync(id);
            return product;
        }

        public async Task<BazzasBazaarService.Order> getOrderById(int id)
        {
            var order = await WCFClient.GetOrderByIdAsync(id);
            return order;
        }
    }
}
