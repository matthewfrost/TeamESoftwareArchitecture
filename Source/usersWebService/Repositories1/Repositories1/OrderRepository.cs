using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories1
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private OrderDBContext context;

        public OrderRepository(OrderDBContext context)
        {
            this.context = context;
        }

            public IEnumerable<Order> GetOrder()
            {
                return context.Order.ToList();
            }

            public Order GetById(int id)
            {
                return context.Order.Find(id);
            }

            public void CreateOrder (Order order)
            {
                context.Order.Add(order);
            }

            public void UpdateOrder(Order order)
            {
                context.Entry(order).State = EntityState.Modified;
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

