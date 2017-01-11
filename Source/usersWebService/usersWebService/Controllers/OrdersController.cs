using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usersWebService.Models;
using Repositories1;

namespace usersWebService.Controllers
{
    public class OrdersController : Controller
    {
        //private ordersEntities odb = new ordersEntities();
        private IOrderRepository orderrepository;

        public OrdersController()
        {
            this.orderrepository = new OrderRepository(new ordersEntities());
        }

        // GET: Orders
        public ActionResult Index()
        {
            Order test2 = new usersWebService.Order();
            test2.ordername = "Dan's Mum";
            Create(test2);
            return View();
        }

        //GET: Order/Create
        public ActionResult Create()
        {
            var records = orderrepository.Order;
            ViewBag.user = new SelectList(records, "orderID", "orderName");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(usersWebService.Order on)
        {
            try
            {
                orderrepository.Order.Add(on);
                orderrepository.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View(on);
            }
        }
        //GET: Order/Edit
        public ActionResult Edit(int id)
        {
            Order orders = orderrepository.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }
        // POST: Order/Edit
        [HttpPost]
        public ActionResult Edit(
            [Bind(
                Include =
                    "orderID, orderName"
                )] Order orders)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    orderrepository.Entry(orders).State = EntityState.Modified;
                    orderrepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.order = new SelectList(orderrepository.Order, "orderID", "orderName",
                    orders.orderid);
                return View(orders);
            }
        }
    }
}
