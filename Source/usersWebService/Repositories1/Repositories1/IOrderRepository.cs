using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;


namespace Repositories1
{
    public interface IOrderRepository : IDisposable
    {
        List<Order> GetAll();
        Order GetById(int orderId);
        void CreateOrder(Order order);
        void UpdateOrder(Order order, int Id);
        void Save();

    }
}
