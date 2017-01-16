using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace usersWebService.Controllers
{
    public class OrderController : ApiController
    {
        OrderRepository orderrepository;

        public OrderController()
        {
            this.orderrepository = new OrderRepository(new OrderdbEntities());
        }
        // GET: api/Order gets everything
        public List <DTOs.Order> Get()
        {
            return orderrepository.GetAll();
        }

        // GET: api/Order/5 gets by id
        public DTOs.Order GetByID(int id)
        {
           return orderrepository.GetById(id);
        }

        // POST: api/Order creates an new order
        public void Post([FromBody] DTOs.Order order)
        {
            orderrepository.CreateOrder(order);
        }

        // PUT: api/Order/5 edits an order
        public void Put(int id, [FromBody]DTOs.Order order)
        {
            orderrepository.UpdateOrder(order, id);
        }
    }
}
