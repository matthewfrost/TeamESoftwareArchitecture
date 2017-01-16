using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;
using Repositories1;

namespace usersWebService
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private OrderdbEntities context;

        public OrderRepository(OrderdbEntities context)
        {
            this.context = context;
        }

        public OrderRepository(IOrderRepository @object)
        {
            this.@object = @object;
        }

        public List<DTOs.Order> GetAll()
        {
            var data = context.Order.ToList();
            List<DTOs.Order> orders = data.Select(o => new DTOs.Order
            (
                Account : o.AccountName,
                cardNumber : o.CarndNumber,
                ProductID : o.ProductId,
                Quantity : o.Quantity,
                ProductName : o.ProductName,
                EAN : o.ProductEan,
                Price : o.TotalPrice
            )).ToList();
            return orders;
        }

        public DTOs.Order GetById(int id)
        {
            var data = context.Order.ToList();
            DTOs.Order orders = data.Where(o => o.Id == id).Select(o => new DTOs.Order
            (
                Account : o.AccountName,
                cardNumber : o.CarndNumber,
                ProductID : o.ProductId,
                Quantity : o.Quantity,
                ProductName : o.ProductName,
                EAN : o.ProductEan,
                Price : o.TotalPrice
            )).FirstOrDefault();
            return orders;

        }

        public void CreateOrder(DTOs.Order order)
        {
            usersWebService.Order ord = new usersWebService.Order();
            ord.Id = (int)order.Id;
            ord.AccountName = order.AccountName;
            ord.CarndNumber = order.AccountName;
            ord.ProductId = order.ProductId;
            ord.Quantity = order.Quantity;
            ord.ProductName = order.ProductName;
            ord.ProductEan = order.ProductEan;
            ord.TotalPrice = order.TotalPrice;
            context.Order.Add(ord);
        }

        public void UpdateOrder(DTOs.Order order, int orderid)
        {

            DTOs.Order orde = GetById(orderid);
            usersWebService.Order ord = new usersWebService.Order();
            ord.Id = (int)orde.Id;
            context.Order.Remove(ord);
            ord.Id = (int)order.Id;
            ord.AccountName = order.AccountName;
            ord.CarndNumber = order.AccountName;
            ord.ProductId = order.ProductId;
            ord.Quantity = order.Quantity;
            ord.ProductName = order.ProductName;
            ord.ProductEan = order.ProductEan;
            ord.TotalPrice = order.TotalPrice;
            context.Order.Add(ord);
            // context.Entry(order).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        private IOrderRepository @object;

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