using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;


namespace Repositories1
{
    public interface IProductrepository : IDisposable
    {
        List<Product> GetAll();
        Product GetById(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product, int Id);
        void Save();
        Product getItemsForBox(int BoxID);
    }
}
