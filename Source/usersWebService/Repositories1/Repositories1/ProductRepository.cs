using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories1
{
    public class ProductRepository : IProductrepository, IDisposable
    {
        private ProductDBContext context;

        public ProductRepository(ProductDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProduct()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public void CreateProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
