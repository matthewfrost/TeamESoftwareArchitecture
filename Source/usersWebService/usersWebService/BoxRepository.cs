using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories1;
using DTOs;

namespace usersWebService
{
    public class BoxRepository : IBoxRepository, IDisposable
    {
        private BoxdbEntities context;
        private ProductdbEntities context1;

        public BoxRepository(BoxdbEntities context, ProductdbEntities context1)
        {
            this.context = context;
            this.context1 = context1;
            
        }

        public BoxRepository()
        {
        }

        public BoxRepository(IBoxRepository @object)
        {
            this.@object = @object;
        }

        public List<DTOs.Box> GetAll()
        {
            var data = context.Box.ToList();
            List<DTOs.Box> boxes = data.Select(b => new DTOs.Box
            (
                ID : b.ID,
                Name : b.Name,
                Price : b.Price,
                Description : b.Description,
               // Contents = b.Contents,
                Visible : b.Visible,
                Available : b.Available
            )).ToList();
            return boxes;
        }

        public DTOs.Box GetById(int id)
        {
            var data = context.Box.ToList();
            DTOs.Box boxes = data.Where(b => b.ID == id).Select(b => new DTOs.Box
            (
                ID: b.ID,
                Name: b.Name,
                Price: b.Price,
                Description: b.Description,
                // Contents = b.Contents,
                Visible: b.Visible,
                Available : b.Available
            )).FirstOrDefault();
            boxes.Contents = GetItemsForBox(id);
            bool Available = true;
            decimal price = 0;
            foreach (DTOs.Product product in boxes.Contents)
            {

                if (product.InStock == false)
                    {
                    Available = false;
                    price = price + product.Price;
                }
            }

            if ((price * 0.1m + price) < (decimal)boxes.Price)
            {
                boxes.Available = false;
            }
            else
            {
                boxes.Available = Available;
            }

            return boxes;
        }

        public bool CreateBox(DTOs.Box boxes)
        {
            if (boxes.Price < 5 || boxes.Price > 25)
            {
                return false;
            }
            else
            { 
                usersWebService.Box box = new usersWebService.Box();
                box.ID = (int)boxes.ID;
                box.Name = boxes.Name;
                box.Price = boxes.Price;
                box.Description = boxes.Description;
                // box.Contents = boxes.Contents;
                box.Visible = boxes.Visible;
                box.Available = boxes.Available;
                context.Box.Add(box);
            return true;
            }
        }

        public void UpdateBox(DTOs.Box boxes, int id)
        {
            DTOs.Box boxe = GetById(id);
            usersWebService.Box box = new usersWebService.Box();
            box.ID = (int)boxe.ID;
            context.Box.Remove(box);
            box.ID = (int)boxes.ID;
            box.Name = boxes.Name;
            box.Price = boxes.Price;
            box.Description = boxes.Description;
           // box.Contents = boxes.Contents;
            box.Visible = boxes.Visible;
            box.Available = boxes.Available;
            context.Box.Add(box);
            Save();
        }

        public List<DTOs.Product >GetItemsForBox(int id)
        {
            var data = context1.Product.ToList();
            List<DTOs.Product> boxe = data.Where(b => b.ID == id).Select(b => new DTOs.Product
            (
                ID: b.ID,
                Ean: b.Ean,
                CategoryID: b.CategoryId,
                CategoryName: b.CategoryName,
                BrandID: b.BrandId,
                BrandName: b.BrandName,
                Name: b.Name,
                Description: b.Description,
                Price: b.Price,
                expectedRestock: b.ExpectedRestock,
                inStock: b.InStock,
                Supplier: b.Supplier
            )).ToList();

            return boxe;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        private IBoxRepository @object;

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