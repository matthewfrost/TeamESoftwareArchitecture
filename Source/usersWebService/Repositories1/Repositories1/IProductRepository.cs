using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories1
{
    public interface IProductrepository : IDisposable
    {
        List<Product> GetAll();
        Product GetById(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(int ID, Product product);
        void Save();
        List<Product> getItemsForBox(int BoxID);
    }
}
