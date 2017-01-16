using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;
using Repositories1;

namespace usersWebService
{
    public class ProductRepository : IProductrepository, IDisposable
    {
        private ProductdbEntities context;

        public ProductRepository(ProductdbEntities context)
        {
            this.context = context;
        }

        public ProductRepository(IProductrepository @object)
        {
            this.@object = @object;
        }

        public List<DTOs.Product> GetAll()
        {
            var data = context.Product.ToList();
            List<DTOs.Product> prod = data.Select(p => new DTOs.Product
            (
                ID : p.ID,
                Ean : p.Ean,
                CategoryID : p.CategoryId,
                CategoryName : p.CategoryName,
                BrandID : p.BrandId,
                BrandName : p.BrandName,
                Name : p.Name,
                Description : p.Description,
                Price : p.Price,
                expectedRestock : p.ExpectedRestock,
                inStock : p.InStock,
                Supplier : p.Supplier
            )).ToList();
            return prod;
        }

        public DTOs.Product GetById(int id)
        {
            var data = context.Product.ToList();
            DTOs.Product prod = data.Where(p => p.ID == id).Select(p => new DTOs.Product
            (
                ID : p.ID,
                Ean : p.Ean,
                CategoryID : p.CategoryId,
                CategoryName : p.CategoryName,
                BrandID : p.BrandId,
                BrandName : p.BrandName,
                Name : p.Name,
                Description : p.Description,
                Price : p.Price,
                expectedRestock : p.ExpectedRestock,
                inStock : p.InStock,
                Supplier : p.Supplier
            )).FirstOrDefault();
            return prod;
        }

        public void CreateProduct(DTOs.Product product)
        {
            usersWebService.Product prod = new usersWebService.Product();
            prod.ID = (int)product.Id;
            prod.Ean = product.Ean;
            prod.CategoryId = product.CategoryId;
            prod.CategoryName = product.CategoryName;
            prod.BrandId = product.BrandId;
            prod.BrandName = product.BrandName;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.ExpectedRestock = product.ExpectedRestock;
            prod.InStock = product.InStock;
            prod.Supplier = product.Supplier;
            context.Product.Add(prod);
        }

        public void UpdateProduct(DTOs.Product product, int Id)
        {

            DTOs.Product prods = GetById(Id);
            usersWebService.Product prod = new usersWebService.Product();
            prod.ID = (int)prods.Id;
            context.Product.Remove(prod);
            prod.ID = (int)product.Id;
            prod.Ean = product.Ean;
            prod.CategoryId = product.CategoryId;
            prod.CategoryName = product.CategoryName;
            prod.BrandId = product.BrandId;
            prod.BrandName = product.BrandName;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.ExpectedRestock = product.ExpectedRestock;
            prod.InStock = product.InStock;
            prod.Supplier = product.Supplier;
            context.Product.Add(prod);
            //context.Entry(product).State = EntityState.Modified;
            Save();
        }

        public DTOs.Product getItemsForBox(int bid)
        {
            var data = context.Product.ToList();
            DTOs.Product prod = data.Where(p => p.ID == bid).Select(p => new DTOs.Product
            (
                ID : p.ID,
                Ean : p.Ean,
                CategoryID: p.CategoryId,
                CategoryName : p.CategoryName,
                BrandID : p.BrandId,
                BrandName : p.BrandName,
                Name : p.Name,
                Description : p.Description,
                Price : p.Price,
                expectedRestock: p.ExpectedRestock,
                inStock : p.InStock,
                Supplier : p.Supplier
            )).FirstOrDefault();
            return prod; 
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        private IProductrepository @object;

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