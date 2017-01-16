using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usersWebService;
using Repositories1;
using DTOs;
using System.Data.Entity;

namespace Repositories2
{
    public class ProductRepository : IProductrepository, IDisposable
    {
        private productsEntities context;

        public ProductRepository(productsEntities context)
        {
            this.context = context;
        }

        public List<DTOs.Product> GetAll()
        {
            var data = context.products.ToList();
            List<DTOs.Product> prod = data.Select(p => new DTOs.Product
            {
                Id = p.Id,
                Ean = p.Ean,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                BrandId = p.BrandId,
                BrandName = p.BrandName,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ExpectedRestock = p.ExpectedRestock,
                InStock = p.InStock,
                Supplier = p.Supplier
            });
            return prod;
        }

        public Product GetById(int id)
        {
            var data = context.products.ToList():
            DTOs.Product prod = data.Where(p => p.productid == id).Select(p => new DTOs.Product
            {
                Id = p.Id,
                Ean = p.Ean,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                BrandId = p.BrandId,
                BrandName = p.BrandName,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ExpectedRestock = p.ExpectedRestock,
                InStock = p.InStock,
                Supplier = p.Supplier
            }).FirstOrDefault();
            return prod;
        }

        public void CreateProduct(DTOs.Product product)
        {
            usersWebService.products prod = new usersWebService.products();
            prod.productid = (int)product.Id;
            prod.productname = product.Name;
            prod.productdescription = product.Description;
            context.products.Add(prod);
        }

        public void UpdateProduct(DTOs.Product product, int productid)
        {
            DTOs.Product prods = GetById(productid);
            usersWebService.products prod = new usersWebService.products();
            prod.productid = (int)prods.Id;
            context.products.Remove(prod);
            prod.productid = (int)product.Id;
            prod.productname = product.Name;
            prod.productdescription = product.Description;
            context.products.Add(prod);
            //context.Entry(product).State = EntityState.Modified;
            Save();
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
